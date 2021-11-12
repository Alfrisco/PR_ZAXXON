using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioClip menuMusica;
    public AudioClip juegoMusica;
    public AudioClip fin;

    public Slider sliderMusic;
    public static AudioManager instance;

    void Awake()
    {
        instance = this;
        InitializeVolume();
    }

    private void InitializeVolume()
    {
        musicSource.volume = PlayerPrefs.GetFloat("MusicVolume", 1.0f);

        sliderMusic.value = musicSource.volume;
    }

    public void PlaySong(AudioClip audioClip)
    {
        musicSource.clip = audioClip;
        musicSource.Play();
    }

    public void OnMusicVolumeUpdate()
    {
        musicSource.volume = sliderMusic.value;
        PlayerPrefs.SetFloat("MusicVolume", musicSource.volume);
        PlayerPrefs.Save();
    }
}
