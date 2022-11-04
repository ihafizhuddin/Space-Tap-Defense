using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour{
    public static AudioManager ins;
    [Header("AudioSource")]
    public AudioSource bgmPlayer;
    public AudioSource sfxPlayer1;
    public AudioSource sfxPlayer2;
    public AudioSource sfxPlayer3;
    public AudioSource menuSfxPlayer;

    [Header("AudioClip")]
    public AudioClip explosionSFX;
    public AudioClip planeHitSFX;
    public AudioClip gameoverSFX;

    void Awake(){
        ins = this;
    }
    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        
    }
    public void playPlaneShooted(){
        sfxPlayer1.clip = explosionSFX;
        sfxPlayer1.Play();
    }

    public void playAlienHitSFX(){
        sfxPlayer2.clip = planeHitSFX;
        sfxPlayer2.Play();
    }
    public void playGameOverSFX(){
        sfxPlayer1.clip = gameoverSFX;
        sfxPlayer1.Play();
        Debug.Log("Play game over sound");
    }

}
