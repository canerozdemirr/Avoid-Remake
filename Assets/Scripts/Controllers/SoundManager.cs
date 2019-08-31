using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioSource musicSource, soundFXSource;

    public AudioClip[] bgMusic;
    public AudioClip uiClick;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Update()
    {
        if (!musicSource.isPlaying && SceneManager.GetActiveScene().buildIndex == 0) PlayMenuMusic();
    }

    public void PlaySoundFX(AudioClip clip)
    {
        soundFXSource.clip = clip;
        soundFXSource.Play();
    }

    public void PlayUIClick()
    {
        soundFXSource.clip = uiClick;
        soundFXSource.Play();
    }

    public void PlayGameOverMusic()
    {
        musicSource.clip = bgMusic[2];
        musicSource.Play();
    }

    public void PlayGameMusic()
    {
        musicSource.clip = bgMusic[1];
        musicSource.Play();
    }

    void PlayMenuMusic()
    {
        musicSource.clip = bgMusic[0];
        musicSource.Play();
    }

}
