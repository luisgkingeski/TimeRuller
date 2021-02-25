using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public GameObject projectile;
    [SerializeField] private float bulletForce;
    private GameObject configs;

    void Start()
    {
        configs = GameObject.FindWithTag("Configs");
    }

    void Update()
    {
        if (!configs.GetComponent<MeshRenderer>().enabled)
        {
            Bullet();
        }
    }

    private void Bullet()
    {
        Vector3 p = Input.mousePosition;
        p.z = 3;
        Vector3 pos = Camera.main.ScreenToWorldPoint(p);
        Vector3 bulletPos = new Vector3(pos.x, pos.y, 4);

        if (Input.GetMouseButtonDown(0) && (bulletPos.y < 1.3f && bulletPos.y > -1f))
        {
            if (bulletPos.x >= 0)
            {
                bulletPos = new Vector3(pos.x + 1, pos.y, 4);
                GameObject bullet = Instantiate(projectile, bulletPos, Quaternion.identity) as GameObject;
                bullet.GetComponent<Transform>().position = new Vector3(bullet.GetComponent<Transform>().position.x + Time.deltaTime,
                   bullet.GetComponent<Transform>().position.y,
                   bullet.GetComponent<Transform>().position.z);
            }
            else
            {
                bulletPos = new Vector3(pos.x - 1, pos.y, 4);
                GameObject bullet = Instantiate(projectile, bulletPos, Quaternion.identity) as GameObject;
            }
        }
    }
}
