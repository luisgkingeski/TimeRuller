using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SlowMotion : MonoBehaviour
{
    //Controla o slow motion

    public float slowDownFactor = 0.05f;
    public float slowDownLenght = 2f;
    private GameObject obj;
    private GameObject obj2;
    public Slider slider;

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "TwoObjWater" || SceneManager.GetActiveScene().name == "TwoObjPine")
        {
            obj = GameObject.Find("Obj1");
            obj2 = GameObject.Find("Obj2");
        }
        else obj = GameObject.FindWithTag("Obj");
    }

    // Update is called once per frame
    void Update()
    {
        slowDownFactor = slider.value;

        if (SceneManager.GetActiveScene().name == "TwoObjWater" || SceneManager.GetActiveScene().name == "TwoObjPine")
        {
            if (!obj.GetComponent<MeshRenderer>().enabled || !obj2.GetComponent<MeshRenderer>().enabled)
            {
                DoSlowMotion();
            }
        }
        else
        {
            if (!obj.GetComponent<MeshRenderer>().enabled)
            {
                DoSlowMotion();
            }
        }

        Time.timeScale += (1f / slowDownLenght) * Time.unscaledDeltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
    }

    public void DoSlowMotion()
    {
        Time.timeScale = slowDownFactor;
        Time.fixedDeltaTime = Time.timeScale * .02f;
    }
}
