using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowMonster : Enemy
{
    protected override void OnMouseDown()
    {
        float x = Random.Range(0f, 1f);
        if (x <= 0.9f)
        {
            base.OnMouseDown();
        }
    }
}
