using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnController : MonoBehaviour
{
    private bool isPlayerTurn = true;

    public int mb;
    public int turn;

    private void Start()
    {
        turn = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPlayerTurn && mb <= 0)
        {
            print("End Enemy turn");
            EndEnemyTurn();
        }

        if (mb <= 0)
        {
            isPlayerTurn = false;
            turn++;
            mb = 6;
        }
    }


    /// <summary>
    /// �⵿���� ��ĭ �Ҹ��մϴ�
    /// </summary>
    public void MinusMb()
    {
        mb--;
    }

    /// <summary>
    /// ���� �÷��̾� �� ���θ� �����մϴ�
    /// </summary>
    /// <returns></returns>
    public bool IsPlayerTurn()
    {
        return isPlayerTurn;
    }

    /// <summary>
    /// �� ���� ������ ���� �÷��̾��� Ȯ��, �⵿���� ȸ���մϴ�
    /// </summary>
    public void EndEnemyTurn()
    {
        mb = 6;
        isPlayerTurn = true;
    }

    /// <summary>
    /// ���� �⵿���� �����մϴ�
    /// </summary>
    /// <returns></returns>
    public int GetMB()
    {
        return mb; 
    }

    public int GetTurnCount()
    {
        return turn;
    }


}
