using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBox : MonoBehaviour
{
    private float _skyImpuls = 1.2f;

    
    void FixedUpdate()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.deltaTime * _skyImpuls);
    }
}
