using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    protected Material BallColor;

    [SerializeField] protected List<GameObject> _allCell;

    public abstract void InitializationCell();

}
