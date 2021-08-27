using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnController : MonoBehaviour
{
    private bool isPlayerTurn = true;
    [SerializeField] private int mb;

    // Update is called once per frame
    void Update()
    {
        if(mb < 0)
        {
            isPlayerTurn = false;
            mb = 6;
        }

        if(!isPlayerTurn && mb < 0)
        {
            EndEnemyTurn();
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


}
