using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigMonster : Enemy
{
    [SerializeField] private GameObject _miniMonster;
    private int _miniMonstersCount = 2;

    public override void DiedMonster()
    {
        for (int i=0; i < _miniMonstersCount; i++)
        {
            Instantiate(_miniMonster, gameObject.transform.position, Quaternion.identity);
        }
        base.DiedMonster();
    }
}
