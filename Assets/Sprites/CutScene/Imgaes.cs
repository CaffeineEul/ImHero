using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Imgaes : MonoBehaviour
{
    public Image image;
    public Sprite[] sprites;
    int start = 0;
    float time = 0f;
    bool b = false;
    private void Awake()
    {
        image = GetComponent<Image>();
    }
    private void Update()
    {
        time += Time.deltaTime;
        if(time > 1f && (start == 2 || start == 3 || start == 4))
        {
            image.sprite = sprites[start];
            start++;
            time = 0f;
        }
        if(time > 6f && start < 7)
        {
            if(start == 6)
            {
                time = 0f;
                Invoke("SceneTrans", 5f);
            }
            image.sprite = sprites[start];
            start++;
            time = 0f;
        }
    }
    void SceneTrans()
    {
        SceneManager.LoadScene("Start");
    }
}
