using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UIHorizontal : UiManager
{
    protected override void Start()
    {
        base.Start();
        _recT.offsetMin = new Vector2(_invizablePos, _recT.offsetMin.y);
        _recT.offsetMax = new Vector2(_invizablePos, _recT.offsetMax.y);
    }

    public override void Move()
    {
        _recT.DOAnchorPos(new Vector2(_checkPos, _recT.anchorMax.y), _speed, false);
    }
}
