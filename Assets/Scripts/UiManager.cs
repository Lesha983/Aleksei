using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UiManager : MonoBehaviour
{
    [Range(0,5)]
    [SerializeField] protected int _speed;
    [SerializeField] protected int _invizablePos,_visiblePos;
    [SerializeField] protected int _checkPos;
    protected RectTransform _recT;
    protected bool _move;

    protected virtual void Start()
    {
        _recT = GetComponent<RectTransform>();
        Invoke("Move", 2f);
    }

    public abstract void Move();


    public void ChangePosition()
    {
        _checkPos = (_checkPos == _invizablePos) ? _visiblePos : _invizablePos;
        _speed = -_speed;
    }
}