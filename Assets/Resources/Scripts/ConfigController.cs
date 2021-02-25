using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ConfigController : MonoBehaviour
{

    private GameObject configs;
    public Slider sliderExplosion, sliderSlow;
    public GameObject panel;
    private Animator configAnimator;
    private bool isConfig = false;
    public float explosionForce;
    public float slowFactor;
    [SerializeField] private float animTime = 0;
    private GameObject reset;
    private bool isReset = false;
    private float resetTime = 0;

    void Start()
    {
        configs = GameObject.FindWithTag("Configs");
        reset = GameObject.FindWithTag("Reset");
        configs.GetComponent<MeshRenderer>().enabled = false;
        panel.SetActive(false);
        configAnimator = configs.GetComponent<Animator>();
        sliderExplosion.minValue = 1;
        sliderExplosion.maxValue = 30;
        sliderSlow.minValue = 0.05f;
        sliderSlow.maxValue = 1f;
        sliderSlow.value = PlayerPrefs.GetFloat("SlowFactor");
        sliderExplosion.value = PlayerPrefs.GetFloat("ExplosionPower");

    }

    public void BtnReset()
    {
        reset.GetComponent<Animator>().SetBool("Reset", true);
        isReset = true;
    }

    public void BtnBulletWater()
    {
        SceneManager.LoadScene("BulletWater");
    }

    public void BtnBulletPine()
    {
        SceneManager.LoadScene("BulletPine");
    }

    public void BtnPine()
    {
        SceneManager.LoadScene("TapToExplodePine");
    }

    public void BtnWater()
    {
        SceneManager.LoadScene("TapToExplodeWater");
    }

    public void BtnTwoWater()
    {
        SceneManager.LoadScene("TwoObjWater");
    }

    public void BtnTwoPine()
    {
        SceneManager.LoadScene("TwoObjPine");
    }

    private void FixedUpdate()
    {
        PlayerPrefs.SetFloat("SlowFactor", sliderSlow.value);
        PlayerPrefs.SetFloat("ExplosionPower", sliderExplosion.value);

        if (isReset)
        {
            resetTime += Time.unscaledDeltaTime;
            if (resetTime >= 0.9f)
            {
                resetTime = 0;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        if (isConfig)
        {
            animTime += Time.unscaledDeltaTime;
            if (animTime >= 0.6f)
            {
                animTime = 0;
                panel.SetActive(true);
            }
        }
        else
        {
            animTime += Time.unscaledDeltaTime;
            if (animTime >= 0.6f)
            {
                animTime = 0;
                configs.GetComponent<MeshRenderer>().enabled = false;
            }
        }
    }

    public void BtnConfig()
    {
        animTime = 0;
        isConfig = !isConfig;

        if (isConfig)
        {
            configs.GetComponent<MeshRenderer>().enabled = true;
            configAnimator.SetBool("Up", true);

        }
        else
        {
            configAnimator.SetBool("Up", false);
            panel.SetActive(false);
        }
    }

    public void BtnBack()
    {
        animTime = 0;
        isConfig = false;
        configAnimator.SetBool("Up", false);
        panel.SetActive(false);
    }

    public void BtnExit()
    {
        SceneManager.LoadScene("Menu");
    }
}
