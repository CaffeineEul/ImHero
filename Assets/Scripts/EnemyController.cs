using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : Object
{
    CharacterInfo characterInfo;

    // Start is called before the first frame update
    void Start()
    {
        characterInfo = GameObject.Find("Character").GetComponent<CharacterInfo>();

    }
}
