using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class operatorPosInfo
{
    public GameObject gameObject;
    public int h;
    public int v;

    public operatorPosInfo(GameObject gObject, int h, int v)
    {
        this.gameObject = gObject;
        this.h = h;
        this.v = v;
    }

}

public class MapInfo : MonoBehaviour
{
    [SerializeField] public GameObject[] allOperators;
    private operatorPosInfo[] operatorPosInfo = new operatorPosInfo[6];

    private void Start()
    {
        operatorPosInfo[0] = new operatorPosInfo(allOperators[0], 0, 0);
        operatorPosInfo[1] = new operatorPosInfo(allOperators[1], 2, 2);
        operatorPosInfo[2] = new operatorPosInfo(allOperators[2], 6, 1);
        operatorPosInfo[3] = new operatorPosInfo(allOperators[3], 6, 6);
        operatorPosInfo[4] = new operatorPosInfo(allOperators[4], 4, 4);
        operatorPosInfo[5] = new operatorPosInfo(allOperators[5], 6, 2);
    }

    public float[,] infoV = new float[8, 8]
    {
        {-2.5f, -2f, -1.5f, -1.0f, -0.5f, 0, 0.5f, 1},
        {-2.0f, -1.5f, -1.0f, -0.5f, 0, 0.5f, 1, 1.5f },
        {-1.5f, -1.0f, -0.5f, 0, 0.5f, 1, 1.5f, 2.0f },
        {-1.0f, -0.5f, 0, 0.5f, 1, 1.5f, 2.0f , 2.5f },
        {-0.5f, 0, 0.5f, 1, 1.5f, 2.0f , 2.5f, 3.0f },
        {0, 0.5f, 1, 1.5f, 2.0f , 2.5f, 3.0f, 3.5f },
        {0.5f, 1, 1.5f, 2.0f , 2.5f, 3.0f, 3.5f, 4.0f },
        { 1, 1.5f, 2.0f , 2.5f, 3.0f, 3.5f, 4.0f, 4.5f}
    };
    public float[,] infoH = new float[8, 8]
    {
        {1.85f, 2.1f, 2.35f, 2.6f, 2.85f, 3.1f, 3.35f, 3.6f},
        {1.6f, 1.85f, 2.1f, 2.35f, 2.6f, 2.85f, 3.1f, 3.35f},
        {1.35f, 1.6f, 1.85f, 2.1f, 2.35f, 2.6f, 2.85f, 3.1f},
        {1.1f, 1.35f, 1.6f, 1.85f, 2.1f, 2.35f, 2.6f, 2.85f },
        {0.85f, 1.1f, 1.35f, 1.6f, 1.85f, 2.1f, 2.35f, 2.6f},
        {0.6f, 0.85f, 1.1f, 1.35f, 1.6f, 1.85f, 2.1f, 2.35f},
        {0.35f, 0.6f, 0.85f, 1.1f, 1.35f, 1.6f, 1.85f, 2.1f},
        {0.1f, 0.35f, 0.6f, 0.85f, 1.1f, 1.35f, 1.6f, 1.85f}
    };
    public bool[,] Exist = new bool[8, 8]
    {
        {false, false,false,false,false,false,false,false},
        {false, false,false,false,false,false,false,false},
        {false, false,false,false,false,false,false,false},
        {false, false,false,false,false,false,false,false},
        {false, false,false,false,false,false,false,false},
        {false, false,false,false,false,false,false,false},
        {false, false,false,false,false,false,false,false},
        {false, false,false,false,false,false,false,false}
    };

    public float GetInfoV(int v, int h)
    {
        return infoV[v,h];
    }
    public float GetInfoH(int v, int h)
    {
        return infoH[v, h];
    }
}
