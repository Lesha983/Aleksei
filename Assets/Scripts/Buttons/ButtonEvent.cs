using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonEvent : ButtonClick
{
    public UnityEvent ButtonAction;

    public override void Action()
    {
        ButtonAction.Invoke();
    }

}
