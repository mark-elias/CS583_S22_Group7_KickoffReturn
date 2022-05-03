using UnityEngine.Audio;
using UnityEngine;
using System;
public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance; 
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.playOnAwake = false;
        }
    }

    public void Play(string name)
    {

        Sound s = Array.Find(sounds, sounds => sounds.name == name);
        if (s != null)
            s.source.Play();
    }

    public void PlayShot(string name)
    {
        Sound s = Array.Find(sounds, sounds => sounds.name == name);
        if (s != null)
            s.source.PlayOneShot(s.clip);
    }
    public void changeVolume(float volume)
    {

        foreach (Sound s in sounds)
        {
            s.source.volume += volume;
        }
    }
}
