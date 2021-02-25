using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    private GameObject child;
    private Rigidbody rb;
    private CapsuleCollider col;
    private GameObject explosion;
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

        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        col.enabled = false;
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        child.SetActive(true);
        explosion.SetActive(true);
        explosion.GetComponent<Explosion>().Explode();
        explosion.SetActive(false);
        sounds.squish.PlayOneShot(sounds.squish.clip);
    }

    public void ThrowObj()
    {
        if (gameObject.name == "Obj1")
        {
            rb.AddForce(Vector3.right * 10, ForceMode.Impulse);
        }
        else rb.AddForce(Vector3.left * 10, ForceMode.Impulse);
    }
}
