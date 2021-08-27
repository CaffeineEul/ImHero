using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnController : MonoBehaviour
{
    private bool isPlayerTurn = true;
    [SerializeField] private int mb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(mb < 0)
        {
            isPlayerTurn = false;
        }
    }

    public void MinusMb()
    {
        mb--;
    }

    public bool IsPlayerTurn()
    {
        return isPlayerTurn;
    }

    public void EndEnemyTurn()
    {
        mb = 6;
        isPlayerTurn = true;
    }
}
