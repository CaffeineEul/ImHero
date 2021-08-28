using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Credit : MonoBehaviour
{
    public Image image;
    public Sprite sprites;
    public bool end = false;
    private void Awake()
    {
        image = GetComponent<Image>();
    }
    public void Call()
    {
        Invoke("ShowCredit", 3f);
    }
    public void ShowCredit()
    {
        image.sprite = sprites;
        end = true;
    }
    public void Quit()
    {
        Application.Quit();
    }
}
