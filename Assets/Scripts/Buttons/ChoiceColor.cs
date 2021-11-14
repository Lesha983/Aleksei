using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceColor : ButtonClick
{
    [SerializeField] private Color _color;
    [SerializeField] private int _indexMaterial;
    [SerializeField] private bool _isAPlayer;

    private ColorRepository _repository;
    private ColorInteractor _interactor;

    public void Start()
    {
        _repository = new ColorRepository();
        _repository.Initialize();

        _interactor = new ColorInteractor(_repository);
        _interactor.Initialize();
    }

    public override void Action()
    {
        MaterialChange();
    }

    private void MaterialChange()
    {
        if (_isAPlayer)
        {
            _interactor.InitColorPlayer(_color,_indexMaterial);
        }
        else
        {
            _interactor.InitColorEnemy(_color, _indexMaterial);
        }
    }
}
