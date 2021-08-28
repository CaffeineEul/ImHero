using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public enum clipsName
    {
        attack,             // [0] V
        cancle,             // [1] V
        click,              // [2] V
        click_menu,         // [3] V
        click_nextTurn,     // [4] 
        gameOver,           // [5] V
        gameOver_Victory,   // [6] V
        heal,               // [7] 
        hit_shield,         // [8] -
        killed,             // [9] V
        move,               // [10] V
        stageBGM,           // [11] V
        titleBGM            // [12] V
    }

    public GameObject[] charactors;
    public AudioClip[] audioClips;

    public float SFXVolume = 0.3f;
    public float BGMVolume = 0.1f;

    [HideInInspector] public AudioSource BGMaudio;
    [HideInInspector] public AudioSource SFXaudio;

    private GameObject menuWindow;
    private UIController uiController;

    private bool isOver = false;
    

    // Start is called before the first frame update
    void Start()
    {
        uiController = GameObject.Find("UIController").GetComponent<UIController>();
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

        
        // SFX: GameOver
        if (uiController.teamcount_temp <= 0 && uiController.enemycount_temp > 0 && !isOver)
        {
            // defeat
            PlaySound(audioClips[(int)clipsName.gameOver], BGMaudio, false, BGMVolume);
            isOver = true;
        }
        else if (uiController.enemycount_temp <= 0 && uiController.teamcount_temp > 0 && !isOver)
        {
            // win
            PlaySound(audioClips[(int)clipsName.gameOver_Victory], BGMaudio, false, BGMVolume);
            isOver = true;
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


    public void CancleSound()
    {
        PlaySound(audioClips[(int)clipsName.cancle], SFXaudio, false, SFXVolume);
    }


    public void MenuClickSound()
    {
        PlaySound(audioClips[(int)clipsName.click_menu], SFXaudio, false, SFXVolume);
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
}