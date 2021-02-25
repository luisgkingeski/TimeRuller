using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Explosion : MonoBehaviour
{
    //controla a explosao

    [SerializeField] private float power = 10f;
    [SerializeField] private float radius = 5f;
    [SerializeField] private float upForce = 1f;
    private ConfigController configController;
    private GameObject configs;
    public Slider slider;

    private void Start()
    {
        configs = GameObject.FindWithTag("Configs");
        configController = GameObject.FindWithTag("ConfigController").GetComponent<ConfigController>();
        if (SceneManager.GetActiveScene().name == "BulletWater" || SceneManager.GetActiveScene().name == "BulletPine")
        {
            slider = configController.sliderExplosion;
        }
    }

    private void Update()
    {
        power = slider.value;
        if ((SceneManager.GetActiveScene().name == "TapToExplodeWater" || SceneManager.GetActiveScene().name == "TapToExplodePine") && !configs.GetComponent<MeshRenderer>().enabled)
        {
            Vector3 p = Input.mousePosition;
            p.z = 3;
            Vector3 pos = Camera.main.ScreenToWorldPoint(p);

            if (pos.x >= -0.5f && pos.x <= 0.5f)
            {
                p.z = 3;
            }
            else p.z = 3.86f;
            pos = Camera.main.ScreenToWorldPoint(p);

            if (Input.GetMouseButtonDown(0))
            {
                transform.position = pos;
                Explode();
            }
        }

    }

    public void Explode()
    {
        power = slider.value;
        Vector3 explosionPosition = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPosition, radius);
        foreach (var hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(power, explosionPosition, radius, upForce, ForceMode.Impulse);
            }
        }
    }
}
