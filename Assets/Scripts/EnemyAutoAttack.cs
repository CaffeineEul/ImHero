using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAutoAttack : MonoBehaviour
{
    public GameObject[] gameObjects;
    private bool OnceAction = true;
    private CharacterInfo characterInfo;
    private ObjectMoveAlgorithm objectMoveAlgorithm;
    // Start is called before the first frame update
    void Start()
    {
        objectMoveAlgorithm = GameObject.Find("ObjectMoveAlgorithm").GetComponent<ObjectMoveAlgorithm>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Action()
    {
        foreach(var i in gameObjects)
        {
            characterInfo = i.GetComponent<CharacterInfo>();
            if (i.transform.gameObject.GetComponent<TileColChk>().isPlayer)
            {
                characterInfo.Attack(i.transform.gameObject.GetComponent<TileColChk>().enemy.GetComponent<Operator>(), characterInfo.GetDamage());
                OnceAction = false;
                return;
            }
        }
        if (!OnceAction)
            return;
        else
        {
            foreach (var i in gameObjects)
            {
                characterInfo = i.GetComponent<CharacterInfo>();
                for (int j = 0; j < 4; j++)
                {
                    int v = characterInfo.ReturnPositionV();
                    int h = characterInfo.ReturnPositionH();
                    if (!OnceAction)
                        return;
                    if (characterInfo.ReturnPositionV() > 0)
                    {
                        characterInfo.objectMoveAlgorithm.GetMoveDir(h, v, h, v - 1);
                        objectMoveAlgorithm.MoveTileMap(1);
                        OnceAction = false;
                    }
                    else if(characterInfo.ReturnPositionV() < 7)
                    {
                        characterInfo.objectMoveAlgorithm.GetMoveDir(h, v, h, v + 1);
                        objectMoveAlgorithm.MoveTileMap(1); 
                        OnceAction = false;
                    }
                    else if(characterInfo.ReturnPositionH() > 0)
                    {
                        characterInfo.objectMoveAlgorithm.GetMoveDir(h, v, h-1,  v);
                        objectMoveAlgorithm.MoveTileMap(1); 
                        OnceAction = false;
                    }
                    else if(characterInfo.ReturnPositionH() < 7)
                    {
                        characterInfo.objectMoveAlgorithm.GetMoveDir(h, v, h+1,  v);
                        objectMoveAlgorithm.MoveTileMap(1); 
                        OnceAction = false;

                    }
                }
            }
        }
    }
}
