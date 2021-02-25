using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject panel;
    public GameObject play;

    public void BtnPlay()
    {
        PlayerPrefs.SetFloat("SlowFactor", 0.05f);
        PlayerPrefs.SetFloat("ExplosionPower", 10);
        panel.SetActive(true);
        play.GetComponent<Animator>().SetBool("Play", true);
    }

    public void Exit()
    {
        Application.Quit();
    }

    void Start()
    {
        Time.timeScale = 1;
        panel.SetActive(false);
    }


}
