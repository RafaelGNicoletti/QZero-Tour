using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    [SerializeField]
    private AudioSource backgroundAudioSource = null;
    [SerializeField]
    private AudioSource sfxAudioSource = null;
    [SerializeField]
    private AudioSource animalAudioSource = null;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    /// <summary>
    /// Stops all music and sounds currently being reproduced.
    /// </summary>
    public void StopAllSounds()
    {
        backgroundAudioSource.Stop();
        sfxAudioSource.Stop();
        animalAudioSource.Stop();
    }

    /// <summary>
    /// Plays a background music.
    /// </summary>
    /// <param name="backgroundMusic">AudioClip to be reproduced.</param>
    public void PlayBackgroundMusic(AudioClip backgroundMusic)
    {
        backgroundAudioSource.clip = backgroundMusic;

            if (backgroundAudioSource.clip != backgroundMusic) {
                backgroundAudioSource.Play();
            }else if (!backgroundAudioSource.isPlaying)
            {
                backgroundAudioSource.Play();
            }        
    }

    /// <summary>
    /// Plays a Sound Effect.
    /// </summary>
    /// <param name="sfx">AudioClip to be reproduced.</param>
    public IEnumerator PlaySFX(AudioClip sfx)
    {
        if (sfxAudioSource.isPlaying)
        {
            yield return new WaitUntil (()=> !sfxAudioSource.isPlaying);
        }
        sfxAudioSource.clip = sfx;
        sfxAudioSource.Play();
    }

    /// <summary>
    /// Sets MUTE = true to background music.
    /// </summary>
    public void MuteBackgroundMusic()
    {
        backgroundAudioSource.mute = true;
    }

    public void UnMuteBackgroundMusic()
    {
        backgroundAudioSource.mute = false;
    }

    /// <summary>
    /// Sets MUTE = true to all sfx.
    /// </summary>
    public void MuteSFX()
    {
        sfxAudioSource.mute = true;
        animalAudioSource.mute = true;
    }

    public void UnMuteSFX()
    {
        sfxAudioSource.mute = false;
        animalAudioSource.mute = false;
    }

    /// <summary>
    /// Changes background music volume.
    /// </summary>
    /// <param name="volume">Float 0 to 1.</param>
    public void ChangeBackgroundVolume(float volume)
    {
        backgroundAudioSource.volume = volume;
    }

    /// <summary>
    /// Stops background music.
    /// </summary>
    public void StopBackgroundMusic()
    {
        backgroundAudioSource.Stop();
    }

    /// <summary>
    /// Stops SFX for animal sounds.
    /// </summary>
    public void StopSFXSound()
    {
        sfxAudioSource.Stop();
    }

    /// <summary>
    /// Check if there is any background music currently playing.
    /// </summary>
    /// <returns>Returns true if something is being played or false if nothing is playing.</returns>
    public bool IsBackgroundPlaying()
    {
        if (backgroundAudioSource.isPlaying)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool IsBackgroundMuted()
    {
        if (backgroundAudioSource.mute)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Plays a sound effect for animal sounds.
    /// </summary>
    /// <param name="animalSound">AudioClip to be reproduced.</param>
    public void PlayAnimalSound(AudioClip animalSound)
    {
        animalAudioSource.clip = animalSound;
        animalAudioSource.Play();
    }

    /// <summary>
    /// Stops SFX.
    /// </summary>
    public void StopAnimalSound()
    {
        animalAudioSource.Stop();
    }
}
