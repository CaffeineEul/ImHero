using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAutoAttack : MonoBehaviour
{
    public GameObject[] gameObjects;
    private bool OnceAction = true;
    private CharacterInfo characterInfo;
    private ObjectMoveAlgorithm objectMoveAlgorithm;
    private TurnController turnController;
    private bool WaitTime = true;
    // Start is called before the first frame update
    void Start()
    {
        objectMoveAlgorithm = GameObject.Find("ObjectMoveAlgorithm").GetComponent<ObjectMoveAlgorithm>();
        turnController = GameObject.Find("TurnController").GetComponent<TurnController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!turnController.IsPlayerTurn() && WaitTime)
        {
            StartCoroutine(Action());
        }
    }
    IEnumerator Action()
    {
        foreach (var i in gameObjects)
        {
            characterInfo = i.GetComponent<CharacterInfo>();
            for(int j = 0; j < i.transform.childCount; j++)
            {
                i.transform.GetChild(j).gameObject.SetActive(true);
                if(i.transform.GetChild(j).gameObject.GetComponent<TileColChk>().isPlayer)
                {
                    characterInfo.Attack(i.transform.GetChild(j).gameObject.GetComponent<TileColChk>().player.GetComponent<Operator>(), characterInfo.GetDamage());
                    turnController.MinusMb();
                    WaitTime = false;
                }
            }
        }
        foreach (var i in gameObjects)
        {
            characterInfo = i.GetComponent<CharacterInfo>();
            for (int j = 0; j < 4; j++)
            {
                int v = characterInfo.ReturnPositionV();
                int h = characterInfo.ReturnPositionH();
                float rand = UnityEngine.Random.Range(0, 3);
                switch(rand)
                {
                    case 0:
                        if (characterInfo.ReturnPositionV() > 0)
                        {
                            characterInfo.objectMoveAlgorithm.GetMoveDir(h, v, h, v - 1);
                            objectMoveAlgorithm.MoveTileMap(1);
                            turnController.MinusMb();
                            WaitTime = false;
                        }
                        break;
                    case 1:
                        if (characterInfo.ReturnPositionV() < 7)
                        {
                            characterInfo.objectMoveAlgorithm.GetMoveDir(h, v, h, v + 1);
                            objectMoveAlgorithm.MoveTileMap(1);
                            turnController.MinusMb();
                            WaitTime = false;
                        }
                        break;
                    case 2:
                        if (characterInfo.ReturnPositionH() > 0)
                        {
                            characterInfo.objectMoveAlgorithm.GetMoveDir(h, v, h - 1, v);
                            objectMoveAlgorithm.MoveTileMap(1);
                            turnController.MinusMb();
                            WaitTime = false;
                        }
                        break;
                    case 3:
                        if (characterInfo.ReturnPositionH() < 7)
                        {
                            characterInfo.objectMoveAlgorithm.GetMoveDir(h, v, h + 1, v);
                            objectMoveAlgorithm.MoveTileMap(1);
                            turnController.MinusMb();
                            WaitTime = false;
                        }
                        break;
                    default: break;
                }
            }
        }
        yield return new WaitForSeconds(0.5f);
        WaitTime = true;
    }
}
