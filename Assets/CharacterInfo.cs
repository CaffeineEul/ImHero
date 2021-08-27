using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInfo : MonoBehaviour
{
    public MapInfo mapInfo;
    public ObjectMoveAlgorithm objectMoveAlgorithm;
    public GameObject[] CanMoveAreas;
    public int h;
    public int v;
    float posX;
    float posY;
    bool ChooseCharacter = true;
    bool appearRange = false;
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

        if(Input.GetMouseButtonDown(0))
        {
            Vector2 wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Ray2D ray = new Ray2D(wp, Vector2.zero);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            //캐릭터 눌렀을 때
            if (hit.collider != null && hit.transform.gameObject.tag == "Character")
            {
                appearRange = true;
                ChooseCharacter = !ChooseCharacter;
            }
            if(hit.collider != null && hit.transform.gameObject.tag == "Range")
            {
                foreach (var i in CanMoveAreas)
                {
                    if(hit.transform.gameObject == i)
                    {
                        //
                        if(transform.position.x > hit.transform.position.x && transform.position.y > hit.transform.position.y)
                        {
                            objectMoveAlgorithm.GetMoveDir(h, v, h, v-1);
                        }
                        else if(transform.position.x > hit.transform.position.x && transform.position.y < hit.transform.position.y)
                        {
                            objectMoveAlgorithm.GetMoveDir(h, v, h, v+1);
                        }
                        else if (transform.position.x < hit.transform.position.x && transform.position.y > hit.transform.position.y)
                        {
                            objectMoveAlgorithm.GetMoveDir(h, v, h+1, v);
                        }
                        else if (transform.position.x < hit.transform.position.x && transform.position.y < hit.transform.position.y)
                        {
                            objectMoveAlgorithm.GetMoveDir(h, v, h-1, v);
                        }
                        appearRange = !appearRange;
                    }
                }
                objectMoveAlgorithm.MoveTileMap();
            }
        }
        AppearCanMoveRange();
    }
    void AppearCanMoveRange()
    {
        if (!appearRange)
            return;
        if(h > 1)
        {
            CanMoveAreas[0].SetActive(true);
        }
        if(h < 7)
        {
            CanMoveAreas[1].SetActive(true);
        }
        if(v > 1)
        {
            CanMoveAreas[2].SetActive(true);
        }
        if(v < 7)
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
        posY = mapInfo.GetInfoH(h, v);
    }
    public void MovePositionV(int var)
    {
        v += var;
        posX = mapInfo.GetInfoV(h, v);
    }
}
