using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    [SerializeField] private AudioSource _menuSound;
    [SerializeField] private AudioSource _titreSound;

    public void Menu()
    {
        _menuSound.Play();
        _titreSound.Stop();
    }

    public void Titre()
    {
        _titreSound.Play();
        _menuSound.Stop();
    }
}
