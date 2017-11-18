using System;
using System.Collections;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public Sound[] sounds;

    private SoundManager() { }

    private static SoundManager instance = null;

    // Game Instance Singleton
    public static SoundManager Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        // if the singleton hasn't been initialized yset
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();

            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.soundName == name);
        if(s == null)
        {
            Debug.LogError("Sound name not found");
            return;
        }
        s.source.Play();
    }
}

