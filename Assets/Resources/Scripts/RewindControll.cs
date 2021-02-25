using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewindControll : MonoBehaviour
{
    public bool isRewinding = false;

    public void StartRewind()
    {
        isRewinding = true;
    }

    public void StopRewind()
    {
        isRewinding = false;
    }
}
