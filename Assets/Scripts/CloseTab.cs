using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseTab : MonoBehaviour
{
    [SerializeField] private GameObject _tab;
    [SerializeField] private Sound _audio;
    [SerializeField] private bool _closeTitre;

    public void TabClose()
    {
        if (_closeTitre)
            _audio.Menu();
        _tab.SetActive(false);
    }
}
