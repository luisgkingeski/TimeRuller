using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeRewind : MonoBehaviour
{
    private bool isRewinding = false;
    public List<PointInTime> pointsInTime;
    Rigidbody rb;
    public float recordTime = 5f;
    private RewindControll _rewindControll;
    private ParticleSystem particles;
    private SoundController sounds;

    void Start()
    {
        pointsInTime = new List<PointInTime>();
        rb = GetComponent<Rigidbody>();
        _rewindControll = GameObject.FindWithTag("RewindControll").GetComponent<RewindControll>();
        sounds = GameObject.FindWithTag("SoundController").GetComponent<SoundController>();
    }

    private void FixedUpdate()
    {
        if (isRewinding)
        {
            Rewinding();
        }
        else Record();
    }

    void Rewinding()
    {
        if (pointsInTime.Count > 0)
        {
            PointInTime poinInTime = pointsInTime[0];
            transform.position = poinInTime.position;
            transform.rotation = poinInTime.rotation;
            pointsInTime.RemoveAt(0);
        }
        else
        {
            if (gameObject.tag == "FractRoot")
            {
                if (SceneManager.GetActiveScene().name == "TwoObjWater" || SceneManager.GetActiveScene().name == "TwoObjPine")
                {
                    GameObject obj1 = GameObject.Find("Obj1");
                    GameObject obj2 = GameObject.Find("Obj2");
                    obj1.GetComponent<MeshRenderer>().enabled = true;
                    obj1.GetComponent<CapsuleCollider>().enabled = true;
                    obj2.GetComponent<MeshRenderer>().enabled = true;
                    obj2.GetComponent<CapsuleCollider>().enabled = true;
                    gameObject.SetActive(false);
                }
                else
                {
                    GameObject.FindWithTag("Obj").GetComponent<MeshRenderer>().enabled = true;
                    GameObject.FindWithTag("Obj").GetComponent<CapsuleCollider>().enabled = true;
                    gameObject.SetActive(false);
                }
            }
            StopRewind();
        }
    }

    void Record()
    {
        if (pointsInTime.Count > Mathf.Round(recordTime / Time.fixedDeltaTime))
        {
            pointsInTime.RemoveAt(pointsInTime.Count - 1);
        }
        pointsInTime.Insert(0, new PointInTime(transform.position, transform.rotation));
    }

    void Update()
    {
        if (_rewindControll.isRewinding)
        {
            StartRewind();
        }

        if (!_rewindControll.isRewinding)
        {
            StopRewind();
        }
    }

    public void StartRewind()
    {
        isRewinding = true;
        rb.isKinematic = true;
    }

    public void StopRewind()
    {
        isRewinding = false;
        rb.isKinematic = false;
    }
}



