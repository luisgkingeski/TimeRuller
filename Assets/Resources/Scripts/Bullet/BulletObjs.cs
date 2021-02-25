﻿using UnityEngine;

public class BulletObjs : MonoBehaviour
{
    private GameObject child;
    private CapsuleCollider col;
    private GameObject configs;
    private SoundController sounds;

    void Start()
    {
        configs = GameObject.FindWithTag("Configs");
        sounds = GameObject.FindWithTag("SoundController").GetComponent<SoundController>();
        col = GetComponent<CapsuleCollider>();
        child = transform.GetChild(0).gameObject;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Parede") || collision.gameObject.CompareTag("Bullet"))
        {
            col.enabled = false;
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            child.SetActive(true);
            sounds.squish.PlayOneShot(sounds.squish.clip);
        }
    }

}