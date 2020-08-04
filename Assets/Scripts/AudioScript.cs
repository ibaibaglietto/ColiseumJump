using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    public AudioClip Clip;

    public AudioSource Source;

    // Start is called before the first frame update
    void Start()
    {
        Source.clip = Clip;
        Source.Play();
    }

 
}
