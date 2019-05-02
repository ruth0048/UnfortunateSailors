using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public Sound[] sounds;
    //public static AudioManager instance;
    // Use this for initialization
    void Awake () {

        //if (instance == null)
        //    instance = this;
        //else
        //{
        //    Destroy(gameObject);
        //    return;
        //}


        foreach (Sound s in sounds)
        {
            s.source=gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;

        }
        Play("Music");
	}

    public void Play(string name)
    {
     Sound s=Array.Find(sounds, sounds => sounds.name == name);
        if(s==null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        //could be done with initial search
        //could use array counter for end instead
        //////////////////////////////////////////////////////untested but should work//////////////////////////////////////////////////
        if(s.source.isPlaying)
        {
            int b = 0;
           while(b<20)
            {
                if (!sounds[b].source.isPlaying)
                {
                    sounds[b].source.clip = s.source.clip;
                    sounds[b].source.volume = s.source.volume;
                    sounds[b].source.Play();
                    return;
                }
                b++;
            }
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        s.source.Play();
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sounds => sounds.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Stop();
    }
    //findobject of type<AudioManager>();
}
