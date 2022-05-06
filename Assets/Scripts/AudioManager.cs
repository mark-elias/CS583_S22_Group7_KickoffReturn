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

    public void Stop(string name)
    {

        Sound s = Array.Find(sounds, sounds => sounds.name == name);
        if (s != null)
            s.source.Stop();
    }

    public void SetLoop(string name, bool input) {
        Sound s = Array.Find(sounds, sounds => sounds.name == name);
        if (s != null)
            s.source.loop = false;
    }

    public void PlayShot(string name)
    {
        Sound s = Array.Find(sounds, sounds => sounds.name == name);
        if (s != null)
            s.source.PlayOneShot(s.clip);
    }

    public void Pause(string name)
    {
        Sound s = Array.Find(sounds, sounds => sounds.name == name);
        if (s != null)
            s.source.Pause();
    }

    public void UnPause(string name)
    {
        Sound s = Array.Find(sounds, sounds => sounds.name == name);
        if (s != null)
            s.source.UnPause();
    }

    public void changeVolume(float volume)
    {

        foreach (Sound s in sounds)
        {
            s.source.volume += volume;
        }
    }
}
