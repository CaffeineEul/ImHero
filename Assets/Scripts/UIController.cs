using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject[] MBTile;
    public Text currentTurn;
    public Text name;
    public Image portrait;

    private int mb;
    TurnController turnController;

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
        UpdateNamePortrait();
    }

    private void UpdateMB()
    {
        if(mb != turnController.GetMB())
        {
            mb = turnController.GetMB();
            if(mb <= 0)
            {
                foreach(GameObject g in MBTile)
                {
                    g.SetActive(true);
                }
            }
            else if(mb < 6)
            {
                MBTile[mb].SetActive(false);
            }
        }
    }

    private void UpdateTurnCount()
    {
        currentTurn.text = turnController.GetTurnCount().ToString();
    }

    private void UpdateNamePortrait()
    {
        Operator target = null;

        if (Input.GetMouseButtonUp(0))
        {

            target = GetClicked2DObject().GetComponent<Operator>();

            if(target!= null)
            {
                name.text = target.name;
                portrait.sprite = target.GetComponent<SpriteRenderer>().sprite;
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

        if(hit)
        {
            target = hit.collider.gameObject;
        }

        return target;
    }
}
