using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseOpen : ButtonClick
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private bool _openButton;

    public override void Action()
    {
        if (_openButton == true)
        {
            _panel.SetActive(true);
        }
        else
        {
            _panel.SetActive(false);
        }
    }

}
