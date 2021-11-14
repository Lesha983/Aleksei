using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UIVertical : UiManager
{
    protected override void Start()
    {
        base.Start();
        _recT.offsetMin = new Vector2(_recT.offsetMin.x, _invizablePos);
        _recT.offsetMax = new Vector2(_recT.offsetMin.x, _invizablePos);
    }

    public override void Move()
    {
        _recT.DOAnchorPos(new Vector2(_recT.anchorMax.x, _checkPos), _speed, false);
    }
}
