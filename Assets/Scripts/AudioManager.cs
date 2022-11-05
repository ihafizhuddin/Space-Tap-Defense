using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public struct Audio{
    public string name;
    public AudioClip clip;

}

public class AudioManager : MonoBehaviour{
    public static AudioManager ins;
    [Header("Volume")]
    [Range(0f,1f)]
    public float bgmVolume;
    [Range(0f,1f)]
    public float sfxVolume;
    public bool isMute;
    
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

    [Header("Clip Audio Array")]
    public Dictionary<string, Audio> audioList = new Dictionary<string, Audio>();
    public Audio[] audio;
    public Audio[] sfx;
    public Audio[] menuSfx;
    public Audio[] bgm;

    void Awake(){
        ins = this;
    }
    // // Start is called before the first frame update
    // void Start(){
        
    // }

    // // Update is called once per frame
    // void Update(){
        
    // }

    public void PlaySFX(string name){
        Audio soundFx = Array.Find(sfx, sfx => sfx.name == name);
        if(sfx == null) return;
        sfxPlayer1.clip = soundFx.clip;
        sfxPlayer1.Play();
    }
    public void PlayMenuSFX(string name){
        Audio menusfx = Array.Find(menuSfx, sfx => sfx.name == name);
        // if(menusfx == null) return;
        sfxPlayer1.clip = menusfx.clip;
        sfxPlayer1.Play();
    }
    public void PlayBgm(string name){
        Audio music = Array.Find(bgm, bgm => bgm.name == name);
        if(bgm == null) return;
        bgmPlayer.clip = music.clip;
        bgmPlayer.Play();

    }
    public void muteSound(){
        isMute = !isMute;
        // sfxPlayer1.Mute = muteSound;
        // sfxPlayer2.Mute = muteSound;
        // sfxPlayer3.Mute = muteSound;
        // bgmPlayer.Mute = muteSound;
        // menuSfxPlayer.Mute = muteSound;
    }
    public void setSfxVolume(float sfxVol){
        sfxVolume = sfxVol;
    }
    public void setBgmVolume(float bgmVol){
        bgmVolume = bgmVol;
    }

}
