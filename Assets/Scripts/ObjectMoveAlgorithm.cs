using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMoveAlgorithm : MonoBehaviour
{
    public GameObject[] gameObjects;
    public float h = 0;
    public float v = 0;
    public float nh = 0;
    public float nv = 0;
    public bool CanClick = true;
    

    public bool IsCanClick()
    {
        return CanClick;
    }
    
    
    public void AllAreaOff()
    {
        foreach(var g in gameObjects)
        {
            g.GetComponent<CharacterInfo>().appearRange = false;
        }
    }
    
    
    public void GetMoveDir(float h, float v, float nh, float nv)
    {
        this.h = h;
        this.v = v;
        this.nh = nh;
        this.nv = nv;
    }
    
    
    public void MoveTileMap(int var)
    {
        if (nh - h > 0)
        {
            foreach (var g in gameObjects)
            {
                for (int i = 0; i < var; i++)
                {
                    if (g.activeInHierarchy && g.GetComponent<CharacterInfo>().ReturnPositionH() < 7)
                    {
                        g.GetComponent<CharacterInfo>().MovePositionH(1);
                        g.GetComponent<CharacterInfo>().MovePositionV(0);
                    }
                }
            }
        }
        if (nh - h < 0)
        {
            foreach (var g in gameObjects)
            {
                for (int i = 0; i < var; i++)
                {
                    if (g.activeInHierarchy && g.GetComponent<CharacterInfo>().ReturnPositionH() > 0)
                    {
                        g.GetComponent<CharacterInfo>().MovePositionH(-1);
                        g.GetComponent<CharacterInfo>().MovePositionV(0);
                    }
                }
            }
        }
        if (nv - v > 0)
        {
            foreach (var g in gameObjects)
            {
                for (int i = 0; i < var; i++)
                {
                    if (g.activeInHierarchy && g.GetComponent<CharacterInfo>().ReturnPositionV() < 7)
                    {
                        g.GetComponent<CharacterInfo>().MovePositionH(0);
                        g.GetComponent<CharacterInfo>().MovePositionV(1);
                    }
                }
            }
        }
        if (nv - v < 0)
        {
            foreach (var g in gameObjects)
            {
                for (int i = 0; i < var; i++)
                {
                    if (g.activeInHierarchy && g.GetComponent<CharacterInfo>().ReturnPositionV() > 0)
                    {
                        g.GetComponent<CharacterInfo>().MovePositionH(0);
                        g.GetComponent<CharacterInfo>().MovePositionV(-1);
                    }
                }
            }
        }

        v = nv;
        h = nh;
    }
}