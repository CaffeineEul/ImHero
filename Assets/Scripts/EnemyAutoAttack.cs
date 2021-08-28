using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAutoAttack : MonoBehaviour
{
    public GameObject[] enemies;
    private bool OnceAction = true;
    private CharacterInfo characterInfo;
    private ObjectMoveAlgorithm objectMoveAlgorithm;
    private TurnController turnController;
    private bool waitTime = false;
    // Start is called before the first frame update


    void Start()
    {
        objectMoveAlgorithm = GameObject.Find("ObjectMoveAlgorithm").GetComponent<ObjectMoveAlgorithm>();
        turnController = GameObject.Find("TurnController").GetComponent<TurnController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!turnController.IsPlayerTurn() && !waitTime)
        {
            if(Input.GetMouseButtonUp(0))
            {
                waitTime = true;
                Go();
            }
        }

        //if (!turnController.IsPlayerTurn() && WaitTime)
        //    StartCoroutine(Action());
        //if (turnController.IsPlayerTurn())
        //{
        //    StopAllCoroutines();
        //    WaitTime = true;
        //}
    }

    private void Go()
    {
        // 공격 체크
        foreach (GameObject enemy in enemies)
        {
            for(int j = 0; j < enemy.transform.childCount; j++)
            {
                GameObject tile = enemy.transform.GetChild(j).gameObject;
                tile.SetActive(true);
                tile.GetComponent<SpriteRenderer>().enabled = false;

                TileColChk tileColChk = tile.GetComponent<TileColChk>();
                CharacterInfo characterInfo = enemy.GetComponent<CharacterInfo>();

                if (characterInfo.me == Operator.Class.Supporter && tileColChk.isEnemy && tileColChk.enemy.GetComponent<Operator>().GetHp() < 6)
                {

                    Debug.Log(characterInfo.name + "가 " + tileColChk.enemy.name + "를 힐했습니다");
                    characterInfo.Heal(tileColChk.enemy.GetComponent<Operator>(), characterInfo.GetDamage());
                    waitTime = false;
                    return;
                }
                else if(tileColChk.isPlayer)
                {
                    Debug.Log(characterInfo.name + "가 " + tileColChk.player.name + "를 공격했습니다");
                    characterInfo.Attack(tileColChk.player.GetComponent<Operator>(), characterInfo.GetDamage());
                    waitTime = false;
                    return;
                }
            }
        }

        turnController.MinusMb();
        waitTime = false;
    }

    //IEnumerator Action()
    //{
    //    WaitTime = false;
    //    foreach (var i in gameObjects)
    //    {
    //        characterInfo = i.GetComponent<CharacterInfo>();
    //        for(int j = 0; j < i.transform.childCount; j++)
    //        {
    //            i.transform.GetChild(j).gameObject.SetActive(true);

    //            if (i.transform.GetChild(j).gameObject.GetComponent<TileColChk>().isPlayer)
    //            {
    //                characterInfo.Attack(i.transform.GetChild(j).gameObject.GetComponent<TileColChk>().player.GetComponent<Operator>(), characterInfo.GetDamage());
    //                turnController.MinusMb();
    //                if (turnController.IsPlayerTurn())
    //                    yield return null;
    //                else
    //                    yield return new WaitForSeconds(1f);
    //            }
    //        }
    //    }
    //    foreach (var i in gameObjects)
    //    {
    //        characterInfo = i.GetComponent<CharacterInfo>();
    //        for (int j = 0; j < 4; j++)
    //        {
    //            int v = characterInfo.ReturnPositionV();
    //            int h = characterInfo.ReturnPositionH();
    //            float rand = UnityEngine.Random.Range(0, 3);
    //            switch(rand)
    //            {
    //                case 0:
    //                    if (characterInfo.ReturnPositionV() > 0)
    //                    {
    //                        int ran = Random.Range(0, characterInfo.Areas.Length / 4);
    //                        characterInfo.objectMoveAlgorithm.GetMoveDir(h, v, h, Mathf.Clamp(v - ran, 0, 7));
    //                        objectMoveAlgorithm.MoveTileMap(ran);
    //                        turnController.MinusMb();
    //                        WaitTime = false;
    //                        if (turnController.IsPlayerTurn())
    //                            yield return null;
    //                        else
    //                            yield return new WaitForSeconds(1f);
    //                    }
    //                    break;
    //                case 1:
    //                    if (characterInfo.ReturnPositionV() < 7)
    //                    {
    //                        int ran = Random.Range(0, characterInfo.Areas.Length / 4);
    //                        characterInfo.objectMoveAlgorithm.GetMoveDir(h, v, h, Mathf.Clamp(v + ran, 0, 7));
    //                        objectMoveAlgorithm.MoveTileMap(ran);
    //                        turnController.MinusMb();
    //                        WaitTime = false;
    //                        if (turnController.IsPlayerTurn())
    //                            yield return null;
    //                        else
    //                            yield return new WaitForSeconds(1f);
    //                    }
    //                    break;
    //                case 2:
    //                    if (characterInfo.ReturnPositionH() > 0)
    //                    {
    //                        int ran = Random.Range(0, characterInfo.Areas.Length / 4);
    //                        characterInfo.objectMoveAlgorithm.GetMoveDir(h, v, Mathf.Clamp(h-ran, 0,  7), v);
    //                        objectMoveAlgorithm.MoveTileMap(ran);
    //                        turnController.MinusMb();
    //                        WaitTime = false;
    //                        if (turnController.IsPlayerTurn())
    //                            yield return null;
    //                        else
    //                            yield return new WaitForSeconds(1f);
    //                    }
    //                    break;
    //                case 3:
    //                    if (characterInfo.ReturnPositionH() < 7)
    //                    {
    //                        int ran = Random.Range(0, characterInfo.Areas.Length / 4);
    //                        characterInfo.objectMoveAlgorithm.GetMoveDir(h, v, Mathf.Clamp(h + ran, 0, 7), v);
    //                        objectMoveAlgorithm.MoveTileMap(ran);
    //                        turnController.MinusMb();
    //                        WaitTime = false;
    //                        if (turnController.IsPlayerTurn())
    //                            yield return null;
    //                        else
    //                            yield return new WaitForSeconds(1f);
    //                    }
    //                    break;
    //                default: 
    //                    break;
    //            }
    //        }
    //    }
    //    if (turnController.IsPlayerTurn())
    //        yield return null;
    //    else
    //        yield return new WaitForSeconds(1f);
    //    WaitTime = true;
    //}
    //}
}
