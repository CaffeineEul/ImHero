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
        if(turnController)

        if(mb != turnController.GetMB())
        {
            mb = turnController.GetMB();

            MBTile[mb].SetActive(false);
        }


    }
}
