using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public List<AudioClip> sounds;
    public AudioSource mainSource, source;
    public static SoundManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void PlaySound(string name)
    {
        foreach(AudioClip sound in sounds)
        {
            Debug.Log(sound.name);
            if(sound.name == name)
            {
                source.clip = sound;
                source.Play();
            }
        }
    }

    public void PlayMusic(string name)
    {
        foreach(AudioClip sound in sounds)
        {
            Debug.Log(sound.name);
            if(sound.name == name)
            {
                mainSource.clip = sound;
                mainSource.Play();
            }
        }
    }

    public void StopSanAndreas(){
        if(mainSource.clip != null && mainSource.clip.name == "sanandreas")
            {
                mainSource.clip = null;
                mainSource.Stop();
            }
    }

    public void ReplaceBackSound(string name)
    {
        foreach (AudioClip sound in sounds)
        {
            Debug.Log(sound.name);
            if (sound.name == name)
            {
                mainSource.clip = sound;
                mainSource.Play();
            }
        }
    }
}
