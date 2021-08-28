using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Tuto : MonoBehaviour
{
    public Image image;
    public Sprite[] sprites;
    int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        print(count);
        if (Input.GetMouseButtonDown(0) && count == 7)
        {
            SceneManager.LoadScene("Main");
        }
        if (Input.GetMouseButtonDown(0) && count < 7)
        {
            count++;
        }
        image.sprite = sprites[count];
    }
}
