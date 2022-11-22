using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds; 
    void Start()
    {
        foreach(Sound s in sounds)
        {
            s.source=gameObject.AddComponent<AudioSource>();
            s.source.name = s.name;
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.loop = s.loop;
        }
       
    }

    
    public void PlaySound(string name)
    {
        foreach (Sound s in sounds)
        {
            if (s.name == name)
                s.source.Play();
        }
    }
     
}
