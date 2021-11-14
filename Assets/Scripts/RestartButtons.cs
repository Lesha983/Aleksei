using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RestartButtons : MonoBehaviour
{
    public UnityEvent Restart;

    private void OnMouseDown()
    {
        Restart.Invoke();
    }
}
