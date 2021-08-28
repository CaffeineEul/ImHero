using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject[] MBTile;
    [SerializeField] private GameObject statusHUD;
    public Text currentTurn;
    public Image portrait;

    public GameObject Menu;
    public GameObject MenuWindow;
    public GameObject DoubleCheck;
    private int mb;
    TurnController turnController;
    public float var= 1f;
    GameObject target;
    // Start is called before the first frame update
    void Awake()
    {
        turnController = GameObject.Find("TurnController").GetComponent<TurnController>();
        mb = turnController.GetMB();
        portrait = GameObject.Find("Sprite").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMB();
        UpdateTurnCount();
        UpdateStatusHUD();
        Time.timeScale = var;
    }

    private void UpdateMB()
    {
        if (mb != turnController.GetMB())
        {
            mb = turnController.GetMB();
            if (mb <= 0)
            {
                foreach (GameObject g in MBTile)
                {
                    g.SetActive(true);
                }
            }
            else if (mb < 6)
            {
                MBTile[mb].SetActive(false);
            }
        }
    }

    private void UpdateTurnCount()
    {
        currentTurn.text = turnController.GetTurnCount().ToString();
    }

    private void UpdateStatusHUD()
    {
        GameObject target = null;

        if (Input.GetMouseButtonUp(0))
        {
            target = GetClicked2DObject();
            
            if (target != null && target.GetComponent<Operator>())
            {
                Text className = statusHUD.GetComponentInChildren<Text>();
                className.text = target.GetComponent<Operator>().GetName();

                UpdateHpDmg(target.GetComponent<Operator>());
                portrait.sprite = target.GetComponent<SpriteRenderer>().sprite;
            }
        }
    }

    private void UpdateHpDmg(Operator target)
    {
        GameObject[] hpCnt = new GameObject[statusHUD.transform.GetChild(1).childCount - 1];
        GameObject[] dmgCnt = new GameObject[statusHUD.transform.GetChild(2).childCount - 1];
        for (int i = 1; i < statusHUD.transform.GetChild(1).childCount; i++)
        {
            hpCnt[i - 1] = statusHUD.transform.GetChild(1).GetChild(i).gameObject;
            dmgCnt[i - 1] = statusHUD.transform.GetChild(2).GetChild(i).gameObject;
        }
        
        if(target != null)
        {
            for(int i  = 0; i < target.GetHp(); i++)
            {
                hpCnt[i].SetActive(true);
            }
            for(int i = target.GetHp(); i < 6; i++)
            {
                hpCnt[i].SetActive(false);
            }
            for (int i = 0; i < target.GetDamage(); i++)
            {
                dmgCnt[i].SetActive(true);
            }
            for (int i = target.GetDamage(); i < 6; i++)
            {
                dmgCnt[i].SetActive(false);
            }
        }
    }

    private GameObject GetClicked2DObject(int layer = -1)
    {
        GameObject target = null;

        int mask = 1 << layer;

        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Ray2D ray = new Ray2D(pos, Vector2.zero);
        RaycastHit2D hit;

        hit = layer == -1 ? Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity) : Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity, mask);

        if (hit)
        {
            target = hit.collider.gameObject;
        }

        return target;
    }

    public void MenuOpen()
    {
        MenuWindow.SetActive(true);
        var = 0f;
    }
    public void Restart()
    {
        MenuWindow.SetActive(false);
        var = 1f;
    }
    public void GameQuitCheck()
    {
        MenuWindow.SetActive(false);
        DoubleCheck.SetActive(true);
    }
    public void GameQuit()
    {
        Application.Quit();
    }
    public void GameQuitCancle()
    {
        MenuWindow.SetActive(false);
        DoubleCheck.SetActive(false); 
        var = 1f;
    }
}
