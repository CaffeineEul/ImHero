using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterInfo : Operator
{
    public MapInfo mapInfo;
    public ObjectMoveAlgorithm objectMoveAlgorithm;
    public GameObject[] CanMoveAreas;
    public GameObject[] CanAttackAreas;
    public Sprite sprite;
    public Class c;
    public int[] nextX = new int[] { 0, 0, 1, -1 };
    public int[] nextY = new int[] { 1, -1, 0, 0 };
    float posX;
    float posY;
    bool ChooseCharacter = true;
    public bool appearRange = false;

    // Start is called before the first frame update
    private void Awake()
    {
        mapInfo = GameObject.Find("MapInfo").GetComponent<MapInfo>();
        objectMoveAlgorithm = GameObject.Find("ObjectMoveAlgorithm").GetComponent<ObjectMoveAlgorithm>();
        posX = transform.position.x;
        posY = transform.position.y;
        mapInfo.Exist[h, v] = true; 
    }
    // Update is called once per frame
    void Update()
    {
        if (IsDead())
        {
            gameObject.SetActive(false);
        } 
        transform.position = new Vector3(posX, posY, 0);

        if(Input.GetMouseButtonDown(0))
        {
            if (!objectMoveAlgorithm.IsCanClick())
            {
                return;
            }
            Vector2 wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Ray2D ray = new Ray2D(wp, Vector2.zero);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            //캐릭터 눌렀을 때
            if (hit.collider != null && hit.transform.gameObject == this.gameObject && turnController.IsPlayerTurn())
            {
                objectMoveAlgorithm.AllAreaOff();
                appearRange = true;
                ChooseCharacter = !ChooseCharacter;
            }
            if(appearRange && hit.collider != null && hit.transform.gameObject.layer == 6 && CanAttack())
            {
                Attack(hit.transform.gameObject.GetComponent<Operator>(), damage);
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
                    turnController.MinusMb();
                    objectMoveAlgorithm.GetMoveDir(h, v, h + 1, v);
                    objectMoveAlgorithm.MoveTileMap();
                    appearRange = !appearRange;
                }
            }
        }
        AppearCanMoveRange();
        AppearCanAttackRange();
    }
    void AppearCanAttackRange()
    {
        if(!appearRange)
        {
            for(int i = 0; i < CanAttackAreas.Length; i++)
            {
                CanAttackAreas[i].SetActive(false);
            }
        }
        for(int i = 0; i < CanAttackAreas.Length / 4; i++)
        {
            for(int j = 0; j < 4; j++)
            {
                int newv = v + nextX[j];
                int newh = h + nextY[i];
                if((newv >= 0 && newv <= 7 && newh >= 0 && newh <= 7) && mapInfo.Exist[newh,newv] )
                {
                    print("*");
                    CanAttackAreas[j * (i + 1)].SetActive(true);
                }
            }
        }

    }
    void AppearCanMoveRange()
    {
        if (!appearRange)
        {
            for(int i = 0; i < 4 ; i++)
            {
                CanMoveAreas[i].SetActive(false);
            }
            return;
        }
        if(v > 0)
        {
            if(mapInfo.Exist[h, v-1])
            {
                CanMoveAreas[0].gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
            }
            CanMoveAreas[0].SetActive(true);
        }
        if(v < 7)
        {
            if (mapInfo.Exist[h, v+1])
            {
                CanMoveAreas[1].gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
            }
            CanMoveAreas[1].SetActive(true);
        }
        if(h > 0)
        {
            if (mapInfo.Exist[h-1, v])
            {
                CanMoveAreas[2].gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
            }
            CanMoveAreas[2].SetActive(true);
        }
        if(h < 7)
        {
            if (mapInfo.Exist[h+1, v])
            {
                CanMoveAreas[3].gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
            }
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
        if(mapInfo.Exist[h+ var, v])
        {
            return;
        }
        mapInfo.Exist[h, v] = false;
        h += var;
        posX = mapInfo.GetInfoV(h, v);
        posY = mapInfo.GetInfoH(h, v);
        mapInfo.Exist[h, v] = true;
    }
    public void MovePositionV(int var)
    {
        if (mapInfo.Exist[h, v + var])
        {
            return;
        }
        mapInfo.Exist[h, v] = false;
        v += var;
        posX = mapInfo.GetInfoV(h, v);
        posY = mapInfo.GetInfoH(h, v);
        mapInfo.Exist[h, v] = true;
    }
}
