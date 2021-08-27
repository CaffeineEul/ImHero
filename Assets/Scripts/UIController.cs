using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject[] MBTile;

    private int mb;
    private bool isMbChange;
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
}
