using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInfo : Operator
{
    public MapInfo mapInfo;
    public ObjectMoveAlgorithm objectMoveAlgorithm;
    public GameObject[] CanMoveAreas;
    public Class c;
    float posX;
    float posY;
    bool ChooseCharacter = true;
    bool appearRange = false;

    // Start is called before the first frame update
    private void Awake()
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

        if(Input.GetMouseButtonDown(0))
        {
            Vector2 wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Ray2D ray = new Ray2D(wp, Vector2.zero);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            //캐릭터 눌렀을 때
            if (hit.collider != null && hit.transform.gameObject == this.gameObject && turnController.IsPlayerTurn())
            {
                appearRange = true;
                ChooseCharacter = !ChooseCharacter;
            }
            if(hit.collider != null && hit.transform.gameObject.tag == "Range")
            {
                if (hit.transform.gameObject == CanMoveAreas[0])
                {
                    turnController.MinusMb();
                    objectMoveAlgorithm.GetMoveDir(h, v, h, v - 1);
                    objectMoveAlgorithm.MoveTileMap();
                    appearRange = !appearRange;
                }
                if (hit.transform.gameObject == CanMoveAreas[1])
                {
                    turnController.MinusMb();
                    objectMoveAlgorithm.GetMoveDir(h, v, h, v + 1);
                    objectMoveAlgorithm.MoveTileMap();
                    appearRange = !appearRange;
                }
                if (hit.transform.gameObject == CanMoveAreas[2])
                {
                    turnController.MinusMb();
                    objectMoveAlgorithm.GetMoveDir(h, v, h - 1, v);
                    objectMoveAlgorithm.MoveTileMap();
                    appearRange = !appearRange;
                }
                if (hit.transform.gameObject == CanMoveAreas[3])
                {
                    objectMoveAlgorithm.GetMoveDir(h, v, h + 1, v);
                    objectMoveAlgorithm.MoveTileMap();
                    appearRange = !appearRange;
                }
            }
        }
        AppearCanMoveRange();
    }
    void AppearCanMoveRange()
    {
        if (!appearRange)
        {
            CanMoveAreas[0].SetActive(false);
            CanMoveAreas[1].SetActive(false);
            CanMoveAreas[2].SetActive(false);
            CanMoveAreas[3].SetActive(false);
            return;
        }
        if(v > 0)
        {
            CanMoveAreas[0].SetActive(true);
        }
        if(v < 7)
        {
            CanMoveAreas[1].SetActive(true);
        }
        if(h > 0)
        {
            CanMoveAreas[2].SetActive(true);
        }
        if(h < 7)
        {
            CanMoveAreas[3].SetActive(true);
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
        posX = mapInfo.GetInfoV(h, v);
        posY = mapInfo.GetInfoH(h, v);
    }
    public void MovePositionV(int var)
    {
        v += var;
        posX = mapInfo.GetInfoV(h, v);
        posY = mapInfo.GetInfoH(h, v);
    }
}
