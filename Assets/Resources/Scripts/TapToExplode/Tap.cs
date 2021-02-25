using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tap : MonoBehaviour
{
    private GameObject child;
    private GameObject explosion;
    private CapsuleCollider col;
    private GameObject configs;
    private SoundController sounds;

    private void Update()
    {
        if (gameObject.GetComponent<Renderer>().enabled)
        {
            explosion.SetActive(false);
        }
    }

    void Start()
    {
        configs = GameObject.FindWithTag("Configs");
        sounds = GameObject.FindWithTag("SoundController").GetComponent<SoundController>();
        col = GetComponent<CapsuleCollider>();
        child = transform.GetChild(0).gameObject;
        explosion = transform.GetChild(1).gameObject;
    }

    private void OnMouseDown()
    {
        if (!configs.GetComponent<MeshRenderer>().enabled)
        {
            col.enabled = false;
            child.SetActive(true);
            explosion.SetActive(true);
            explosion.GetComponent<Explosion>().Explode();
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            sounds.squish.PlayOneShot(sounds.squish.clip);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Parede"))
        {
            col.enabled = false;
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            child.SetActive(true);
            explosion.SetActive(true);
            explosion.GetComponent<Explosion>().Explode();
            explosion.SetActive(false);
            sounds.squish.PlayOneShot(sounds.squish.clip);
        }
    }
}
