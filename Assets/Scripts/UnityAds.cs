using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class UnityAds : MonoBehaviour
{
    private int advCount = 0;

    void Start()
    {
        if (Advertisement.isSupported)
        {
            Advertisement.Initialize("4448543", false);
        }
    }

    public void PlayerLose()
    {
        advCount++;
        if(Advertisement.IsReady() && advCount % 2 == 0)
        {
            Advertisement.Show("video");
        }
    }
}
