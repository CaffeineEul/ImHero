using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public enum clipsName
    {
        attack,         // [0] V
        cancle,         // [1] 
        click,          // [2] V
        click_menu,     // [3] V
        click_nextTurn, // [4] 
        gameOver,       // [5]
        heal,           // [6]
        hit,            // [7]
        hit_shield,     // [8]
        killed,         // [9]
        move,           // [10] V
        stageBGM,       // [11] V
        titleBGM        // [12]
    }

    public GameObject[] charactors;
    public AudioClip[] audioClips;

    public float SFXVolume = 0.3f;
    public float BGMVolume = 0.03f;

    [HideInInspector] public AudioSource BGMaudio;
    [HideInInspector] public AudioSource SFXaudio;

    private bool isMenuON = false;
    private GameObject menuWindow;
    

    // Start is called before the first frame update
    void Start()
    {
        menuWindow = GameObject.Find("MenuWindow");
        SFXaudio = gameObject.AddComponent<AudioSource>();
        BGMaudio = gameObject.AddComponent<AudioSource>();

        // InGame BGM Play 
        PlaySound(audioClips[(int)clipsName.stageBGM], BGMaudio, true, BGMVolume);
    }


    // Update is called once per frame
    void Update()
    {
        // SFX: Character Click && Move
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 character = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Ray2D ray = new Ray2D(character, Vector2.zero);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit.collider != null && hit.transform.gameObject.CompareTag("Character"))
            {
                PlaySound(audioClips[(int)clipsName.click], SFXaudio, false, SFXVolume);
            }
            else if (hit.collider != null && hit.transform.gameObject.CompareTag("Range"))
            {
                PlaySound(audioClips[(int)clipsName.move], SFXaudio, false, SFXVolume);
            }
        }
    }


    public void PlaySound(AudioClip audioClip, AudioSource audioPlayer, bool isLoop, float volume)
    {
        audioPlayer.Stop();
        audioPlayer.clip = audioClip;
        audioPlayer.loop = isLoop;
        audioPlayer.volume = volume;
        audioPlayer.Play();
    }

    public void MenuOFF()
    {
        isMenuON = false;
    }

    public void MenuClickSound()
    {
        PlaySound(audioClips[(int)clipsName.click_menu], SFXaudio, false, SFXVolume);
        isMenuON = true;
    }


    public void AttackSound()
    {
        PlaySound(audioClips[(int)clipsName.attack], SFXaudio, false, SFXVolume);
    }


    public void HealSound()
    {
        PlaySound(audioClips[(int)clipsName.heal], SFXaudio, false, SFXVolume);
    }


    public void DeadSound()
    {
        PlaySound(audioClips[(int)clipsName.killed], SFXaudio, false, SFXVolume);
    }
    

    public void HitSound()
    {
        PlaySound(audioClips[(int)clipsName.hit], SFXaudio, false, SFXVolume);

        //PlaySound(audioClips[(int)clipsName.hit_shield], SFXaudio, false, SFXVolume);
    }
}
