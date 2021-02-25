using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //Controla as balas

    private bool left;

    void Start()
    {
        Destroy(gameObject, 10);
        if (transform.position.x >= 0)
        {
            left = true;
        }
    }

    private void Update()
    {
        if (GetComponent<TimeRewind>().pointsInTime.Count <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        if (left)
        {
            transform.position = new Vector3(transform.position.x - (Time.deltaTime * 3), transform.position.y, transform.position.z);
        }
        else transform.position = new Vector3(transform.position.x + (Time.deltaTime * 3), transform.position.y, transform.position.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //desativa o freeze se a colisao for com balas normais


        if (collision.gameObject.CompareTag("Parede"))
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Bullet"))
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }
        GetComponent<Explosion>().Explode();
    }
}
