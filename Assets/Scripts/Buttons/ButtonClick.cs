using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ButtonClick : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSrc;
    protected void OnMouseDown()
    {
        transform.localScale = new Vector2(1.2f, 1.2f);
        _audioSrc.Play();
        Action();
    }

    protected void OnMouseUp()
    {
        transform.localScale = new Vector2(1f, 1f);
    }

    public abstract void Action();
}
