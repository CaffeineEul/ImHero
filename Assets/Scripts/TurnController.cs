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
    /// 기동력을 한칸 소모합니다
    /// </summary>
    public void MinusMb()
    {
        mb--;
    }

    /// <summary>
    /// 현재 플레이어 턴 여부를 리턴합니다
    /// </summary>
    /// <returns></returns>
    public bool IsPlayerTurn()
    {
        return isPlayerTurn;
    }

    /// <summary>
    /// 적 턴이 끝나고 현재 플레이어턴 확보, 기동력을 회복합니다
    /// </summary>
    public void EndEnemyTurn()
    {
        mb = 6;
        isPlayerTurn = true;
    }

    /// <summary>
    /// 남은 기동력을 리턴합니다
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
