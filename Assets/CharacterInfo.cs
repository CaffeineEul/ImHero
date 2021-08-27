using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInfo : MonoBehaviour
{
    public MapInfo mapInfo;
    public ObjectMoveAlgorithm objectMoveAlgorithm;
    public int h;
    public int v;
    float posX;
    float posY;
    bool can = true;
    // Start is called before the first frame update
    void Start()
    {
        mapInfo = GameObject.Find("MapInfo").GetComponent<MapInfo>();
        objectMoveAlgorithm = GameObject.Find("ObjectMoveAlgorithm").GetComponent<ObjectMoveAlgorithm>();
        posX = transform.position.x;
        posY = transform.position.y;
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(posX, posY, 0);

        if(Input.GetMouseButton(0) && can)
        {
            print("*");
            Vector2 wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Ray2D ray = new Ray2D(wp, Vector2.zero);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit.collider != null && hit.transform.gameObject.tag == "Character")
            {
                print("*8");
                objectMoveAlgorithm.GetMoveDir(h, v, h + 1, v);
                objectMoveAlgorithm.MoveTileMap();
                can = false;
            }
        }
    }
    public int ReturnPositionH()
    {
        return h;
    }
    public int ReturnPositionV()
    {
        return v;
    }
    public void MovePositionH(int var)
    {
        h += var;
        posY = mapInfo.GetInfoH(h, v);
    }
    public void MovePositionV(int var)
    {
        v += var;
        posX = mapInfo.GetInfoV(h, v);
    }
}
