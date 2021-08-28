using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileColChk : MonoBehaviour
{
    public bool isEnemy = false;
    public GameObject enemy;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            isEnemy = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            isEnemy = true;
            enemy = collision.gameObject;
        }
    }
}
