using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : CharacterInfo
{
    MapInfo mapInfo;

    private void Awake()
    {
        mapInfo = GameObject.Find("MapInfo").GetComponent<MapInfo>();
    }


}
