using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterInfo : Operator
{
    public UIController uIController;
    public MapInfo mapInfo;
    public ObjectMoveAlgorithm objectMoveAlgorithm;
    public GameObject[] Areas;
    public Sprite sprite;
    public Class c;
    public bool appearRange = false;


    private SoundController soundController;
    private bool ChooseCharacter = true;
    private float posX;
    private float posY;

    

    // Start is called before the first frame update
    private void Start()
    {
        soundController = GameObject.Find("SoundController").GetComponent<SoundController>();
        mapInfo = GameObject.Find("MapInfo").GetComponent<MapInfo>();
        objectMoveAlgorithm = GameObject.Find("ObjectMoveAlgorithm").GetComponent<ObjectMoveAlgorithm>();
        uIController = GameObject.Find("UIController").GetComponent<UIController>();
        posX = transform.position.x;
        posY = transform.position.y;
        mapInfo.Exist[h, v] = true; 
    }


    // Update is called once per frame
    void Update()
    {
        if (uIController.AllStop)
            return;
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

            if (hit.collider != null)
            {
                for(int i = 0; i < Areas.Length; i++)
                {
                    if(hit.transform.gameObject == Areas[i])
                    {
                        if(hit.transform.gameObject.GetComponent<TileColChk>().isEnemy)
                        {
                            turnController.MinusMb();
                            Attack(hit.transform.gameObject.GetComponent<TileColChk>().enemy.GetComponent<Operator>(), damage);
                        }
                        else if(i % 4 == 0)
                        {
                            turnController.MinusMb();
                            objectMoveAlgorithm.GetMoveDir(h, v, h, v - (1 + i / 4));
                            objectMoveAlgorithm.MoveTileMap((1 + i / 4));
                            appearRange = !appearRange;
                            return;
                        }
                        else if(i % 4 == 1)
                        {
                            turnController.MinusMb();
                            objectMoveAlgorithm.GetMoveDir(h, v, h, v + (1 + i / 4));
                            objectMoveAlgorithm.MoveTileMap((1 + i / 4));
                            appearRange = !appearRange; 
                            return;
                        }
                        else if(i % 4 == 2)
                        {
                            turnController.MinusMb();
                            objectMoveAlgorithm.GetMoveDir(h, v, h - (1 + i / 4), v );
                            objectMoveAlgorithm.MoveTileMap((1 + i / 4));
                            appearRange = !appearRange; 
                            return;
                        }
                        else if(i % 4 == 3)
                        {
                            turnController.MinusMb();
                            objectMoveAlgorithm.GetMoveDir(h, v, h + (1 + i / 4), v);
                            objectMoveAlgorithm.MoveTileMap((1 + i / 4));
                            appearRange = !appearRange;
                            return;
                        }
                    }
                }
            }
        }
        AppearCanAttackRange();
    }


    void AppearCanAttackRange()
    {
        if (!appearRange)
        {
            for (int i = 0; i < Areas.Length; i++)
            {
                Areas[i].SetActive(false);
            }
            return;
        }

        for (int i = 0; i < Areas.Length / 4; i++)
        {
            if (v > 0 + i)
            {
                if (mapInfo.Exist[h, v - (1 + i)])
                {
                    Areas[(4 * i) + 0].gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
                }
                Areas[(4 * i) + 0].SetActive(true);
            }
            if (v < 7 - i)
            {
                if (mapInfo.Exist[h, v + (1 + i)])
                {
                    Areas[(4 * i) + 1].gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
                }
                Areas[(4 * i) + 1].SetActive(true);
            }
            if (h > 0 + i)
            {
                if (mapInfo.Exist[h - (1 + i), v])
                {
                    Areas[(4 * i) + 2].gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
                }
                Areas[(4 * i) + 2].SetActive(true);
            }
            if (h < 7 - i)
            {
                if (mapInfo.Exist[h + (1 + i), v])
                {
                    Areas[(4 * i) + 3].gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
                }
                Areas[(4 * i) + 3].SetActive(true);
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
        if (mapInfo.Exist[Mathf.Clamp(h + var, 0, 7), v])
        {
            return;
        }
        mapInfo.Exist[h, v] = false;
        h = Mathf.Clamp(h + var, 0, 7);
        posX = mapInfo.GetInfoV(h, v);
        posY = mapInfo.GetInfoH(h, v);
        mapInfo.Exist[h, v] = true;

        //soundController.PlaySound(soundController.audioClips[(int)SoundController.clipsName.move], soundController.SFXaudio, false);
        
    }


    public void MovePositionV(int var)
    {
        if (mapInfo.Exist[h, Mathf.Clamp(v + var, 0, 7)])
        {
            return;
        }
        mapInfo.Exist[h, v] = false;
        v = Mathf.Clamp(v + var, 0, 7);
        posX = mapInfo.GetInfoV(h, v);
        posY = mapInfo.GetInfoH(h, v);
        mapInfo.Exist[h, v] = true;
        //soundController.PlaySound(soundController.audioClips[(int)SoundController.clipsName.move], soundController.SFXaudio, false);
    }
}
