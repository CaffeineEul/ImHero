using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public enum clipsName
    {
        attack,         // [0]
        cancle,         // [1]
        click,          // [2] V
        click_menu,     // [3]
        click_nextTurn, // [4]
        gameOver,       // [5]
        heal,           // [6]
        hit,            // [7]
        hit_shield,     // [8]
        killed,         // [9]
        move,           // [10]
        stageBGM,       // [11] V
        titleBGM        // [12]
    }

    public GameObject[] charactors;
    public AudioClip[] audioClips;

    [HideInInspector] public AudioSource BGMaudio;
    [HideInInspector] public AudioSource SFXaudio;

 
    // Start is called before the first frame update
    void Start()
    {
        SFXaudio = gameObject.AddComponent<AudioSource>();
        BGMaudio = gameObject.AddComponent<AudioSource>();

        // InGame BGM Play 
        PlaySound(audioClips[(int)clipsName.stageBGM], BGMaudio, true);
    }


    // Update is called once per frame
    void Update()
    {
        // SFX: Character Click
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 character = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Ray2D ray = new Ray2D(character, Vector2.zero);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit.collider != null && hit.transform.gameObject.CompareTag("Character"))
            {
                Debug.Log("!");
                PlaySound(audioClips[(int)clipsName.move], SFXaudio, false);
            }
        }
    }


    public void PlaySound(AudioClip audioClip, AudioSource audioPlayer, bool isLoop)
    {
        audioPlayer.Stop();
        audioPlayer.clip = audioClip;
        audioPlayer.loop = isLoop;
        audioPlayer.Play();
    }
}
