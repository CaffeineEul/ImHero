using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileColChk : MonoBehaviour
{
    public bool isEnemy = false;
    public bool isPlayer = false;
    public GameObject enemy;
    public GameObject player;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            isEnemy = false;
        }
        else if(collision.gameObject.layer == 7)
        {
            isPlayer = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            isEnemy = true;
            enemy = collision.gameObject;
        }
        if (collision.gameObject.layer == 7)
        {
            isPlayer = true;
            player = collision.gameObject;
        }
    }
}
