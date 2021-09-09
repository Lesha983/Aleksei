using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Island : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;

    private void FixedUpdate()
    {
        transform.Rotate(0, Time.deltaTime * _speed,0);
    }

}
