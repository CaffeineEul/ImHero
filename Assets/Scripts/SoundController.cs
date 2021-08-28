using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public GameObject[] charactors;
    public AudioClip[] audioClips;

    private AudioSource BGMaudio;
    private AudioSource SFXaudio;


    // Start is called before the first frame update
    void Start()
    {
        // In Game BGM Play 
        BGMaudio = gameObject.AddComponent<AudioSource>();
        PlaySound(audioClips[11], BGMaudio, true);
    }


    // Update is called once per frame
    void Update()
    {
        // SFX: Character Click
        if (Input.GetMouseButton(0))
        {
            Vector2 character = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Ray2D ray = new Ray2D(character, Vector2.zero);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit.collider != null && hit.transform.gameObject.CompareTag("Character"))
            {
                SFXaudio = gameObject.AddComponent<AudioSource>();
                PlaySound(audioClips[2], SFXaudio, false);
            }
        }
    }


    public void PlaySound(AudioClip audioClip, AudioSource audioPlayer, bool isLoop)
    {
        //audioPlayer.Stop();
        audioPlayer.clip = audioClip;
        audioPlayer.loop = isLoop;
        audioPlayer.Play();
    }
}
