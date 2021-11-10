using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowMonster : Enemy
{
    protected override void OnMouseDown()
    {
        float _chanceDodge = Random.Range(0f, 1f);
        if (_chanceDodge <= 0.9f)
        {
            base.OnMouseDown();
        }
    }
}
