using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioSource squish;
    public AudioSource rewind;
    private int soundMod = 1;

    void Start()
    {
        squish = transform.GetChild(0).gameObject.GetComponent<AudioSource>();
        rewind = transform.GetChild(1).gameObject.GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        squish.pitch = Time.timeScale * soundMod;
    }

    public void StopAll()
    {
        squish.Stop();
    }

    public void BtnPositiveSound()
    {
        soundMod = 1;
        rewind.Stop();
    }

    public void BtnNegativeSound()
    {
        soundMod = -1;
        rewind.Play();
    }
}
