using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject[] MBTile;
    public Text currentTurn;

    private int mb;
    TurnController turnController;

    // Start is called before the first frame update
    void Start()
    {
        turnController = GameObject.Find("TurnController").GetComponent<TurnController>();
        mb = turnController.GetMB();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMB();
        UpdateTurnCount();
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
}
