using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAutoAttack : MonoBehaviour
{
    public GameObject[] enemies;
    CharacterInfo characterInfo;
    private ObjectMoveAlgorithm objectMoveAlgorithm;
    private TurnController turnController;
    private bool waitTime = false;
    private bool isLastPlayerTurn = true;
    // Start is called before the first frame update


    void Start()
    {
        objectMoveAlgorithm = GameObject.Find("ObjectMoveAlgorithm").GetComponent<ObjectMoveAlgorithm>();
        turnController = GameObject.Find("TurnController").GetComponent<TurnController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!turnController.IsPlayerTurn() && isLastPlayerTurn)
        {
            waitTime = true;
            StartCoroutine(waitTimefalse());
        }

        if (!turnController.IsPlayerTurn() && !waitTime)
        {
            if (Input.GetMouseButtonUp(0))
            {
                waitTime = true;
                Go();
            }
        }

        isLastPlayerTurn = turnController.IsPlayerTurn();
    }

    private void Go()
    {
        // ���� üũ
        foreach (GameObject enemy in enemies)
        {
            for (int j = 0; j < enemy.transform.childCount; j++)
            {
                GameObject tile = enemy.transform.GetChild(j).gameObject;
                tile.SetActive(true);
                tile.GetComponent<SpriteRenderer>().enabled = false;

                TileColChk tileColChk = tile.GetComponent<TileColChk>();
                characterInfo = enemy.GetComponent<CharacterInfo>();

                // ������ ��
                if (characterInfo.me == Operator.Class.Supporter && tileColChk.isEnemy && tileColChk.enemy.GetComponent<Operator>().GetHp() < 6)
                {

                    Debug.Log(characterInfo.name + "�� " + tileColChk.enemy.name + "�� ���߽��ϴ�");
                    characterInfo.Heal(tileColChk.enemy.GetComponent<Operator>(), characterInfo.GetDamage());
                    waitTime = false;
                    return;
                }
                else if (characterInfo.me != Operator.Class.Supporter && tileColChk.isPlayer) // �����϶�
                {
                    Debug.Log(characterInfo.name + "�� " + tileColChk.player.name + "�� �����߽��ϴ�");
                    characterInfo.Attack(tileColChk.player.GetComponent<Operator>(), characterInfo.GetDamage());
                    waitTime = false;
                    return;
                }
            }
        }

        // ������ ����� ������ ������ ����� ������ �������� ������ �Ÿ� ��ŭ �̵�
        GameObject moveEnemy = enemies[Random.Range(0, 3)];
        characterInfo = moveEnemy.GetComponent<CharacterInfo>();

        int v = characterInfo.ReturnPositionV();
        int h = characterInfo.ReturnPositionH();

        float rand = UnityEngine.Random.Range(1, 3);
        switch (rand)
        {
            case 0:
                if (characterInfo.ReturnPositionV() > 0)
                {
                    int ran = Random.Range(1, characterInfo.Areas.Length / 4);
                    Debug.Log(moveEnemy.name + "�� " + rand + "�������� " + ran + "��ŭ �̵��մϴ�");
                    characterInfo.objectMoveAlgorithm.GetMoveDir(h, v, h, Mathf.Clamp(v - ran, 0, 7));
                    objectMoveAlgorithm.MoveTileMap(ran);
                }
                break;

            case 1:
                if (characterInfo.ReturnPositionV() < 7)
                {
                    int ran = Random.Range(1, characterInfo.Areas.Length / 4);
                    Debug.Log(moveEnemy.name + "�� " + rand + "�������� " + ran + "��ŭ �̵��մϴ�");
                    characterInfo.objectMoveAlgorithm.GetMoveDir(h, v, h, Mathf.Clamp(v + ran, 0, 7));
                    objectMoveAlgorithm.MoveTileMap(ran);
                }
                break;

            case 2:
                if (characterInfo.ReturnPositionH() > 0)
                {
                    int ran = Random.Range(1, characterInfo.Areas.Length / 4);
                    Debug.Log(moveEnemy.name + "�� " + rand + "�������� " + ran + "��ŭ �̵��մϴ�");
                    characterInfo.objectMoveAlgorithm.GetMoveDir(h, v, Mathf.Clamp(h - ran, 0, 7), v);
                    objectMoveAlgorithm.MoveTileMap(ran);
                }
                break;

            case 3:
                if (characterInfo.ReturnPositionH() < 7)
                {
                    int ran = Random.Range(1, characterInfo.Areas.Length / 4);
                    Debug.Log(moveEnemy.name + "�� " + rand + "�������� " + ran + "��ŭ �̵��մϴ�");
                    characterInfo.objectMoveAlgorithm.GetMoveDir(h, v, Mathf.Clamp(h + ran, 0, 7), v);
                    objectMoveAlgorithm.MoveTileMap(ran);
                }
                break;
        }

        turnController.MinusMb();
        StartCoroutine(waitTimefalse());
        return;

    }

    private IEnumerator waitTimefalse()
    {
        yield return  new WaitForSeconds(0.2f);
        waitTime = false;
    }
}
