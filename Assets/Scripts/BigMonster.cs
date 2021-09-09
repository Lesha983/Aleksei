using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigMonster : Enemy
{
    [SerializeField] private GameObject _miniMonster;

    public override void DiedMonster()
    {
        for (int i=0; i < 2; i++)
        {
            Instantiate(_miniMonster, gameObject.transform.position, Quaternion.identity);
        }
        base.DiedMonster();
    }
}
