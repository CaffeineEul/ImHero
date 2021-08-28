using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeManager : MonoBehaviour
{
    public AudioClip IntroBGM;
 
    private AudioSource audioPlayer;
    
    
    private void Start()
    {
        audioPlayer = gameObject.AddComponent<AudioSource>();

        audioPlayer.clip = IntroBGM;
        audioPlayer.loop = true;
        audioPlayer.volume = 0.3f;
        audioPlayer.Play();
    }


    public void LoadMainScene()
    {
        SceneManager.LoadScene("Main");
    }
}