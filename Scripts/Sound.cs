using UnityEngine;
using UnityEngine.Audio;

//Created using: https://www.youtube.com/watch?v=6OT43pvUyfY&ab_channel=Brackeys

[System.Serializable]
public class Sound 
{

    public string name;

    public AudioClip clip;

    public AudioMixerGroup group;

    [Range(0f, 1f)]
    public float volume;
    [Range(.1f, 3f)]
    public float pitch;

    public bool loop;

    [HideInInspector]
    public AudioSource source;
}
