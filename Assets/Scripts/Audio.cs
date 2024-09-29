using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioSource audioSource;
    
    public AudioClip clip; 
    // Start is called before the first frame update

    public void Beep(){
        audioSource.PlayOneShot(clip);
    }

    void Start()
    {
        //audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }
}

