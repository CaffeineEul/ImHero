using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAutoAttack : MonoBehaviour
{
    public GameObject[] gameObjects;
    private bool OnceAction = true;
    private CharacterInfo characterInfo;
    // Start is called before the first frame update
    void Start()
    {
        
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
                    if (i.GetComponent<CharacterInfo>().v > 0)
                    {

                    }
                }
            }
        }
    }
}
