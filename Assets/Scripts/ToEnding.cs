using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ToEnding : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ReLoad()
    {
        SceneManager.LoadScene("Main");
    }
    public void ToEnd()
    {
        SceneManager.LoadScene("Ending");
    }
}
