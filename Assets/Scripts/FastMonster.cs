using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastMonster : Enemy
{
    private Vector3 _scaleDecrease = new Vector3(0.25f, 0.25f, 0.25f);

    protected override void OnMouseDown()
    {
        base.OnMouseDown();
        if (transform.localScale.x > 0.5f)
            transform.localScale -= _scaleDecrease;
    }
}
