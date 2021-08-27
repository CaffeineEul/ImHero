using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapInfo : MonoBehaviour
{
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

    public float GetInfoV(int v, int h)
    {
        return infoV[v,h];
    }
    public float GetInfoH(int v, int h)
    {
        return infoH[v, h];
    }
}
