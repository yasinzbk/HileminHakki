using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Ses
{
    public string Ad;

    public AudioClip klip;

    public bool dongu;

    [Range(0f,1f)]
    public float siddeti;

    [Range(.1f, 3f)]
    public float perde;

    [HideInInspector]
    public AudioSource sesKaynagi;
 
}
