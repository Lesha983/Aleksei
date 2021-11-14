using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorInteractor : Interactor
{
    private ColorRepository _repository;

    public Color _colorPlayer =>_repository.ColorBallPlayer;
    public Color _colorEnemy => _repository.ColorBallEnemy;
    public int _indexPlayer => _repository.IndexMaterialPlayer;
    public int _indexEnemy => _repository.IndexMaterialEnemy;

    public ColorInteractor(ColorRepository repository)
    {
        _repository = repository;
    }

    public void InitColorPlayer(Color color, int index)
    {
        _repository.ColorBallPlayer = color;
        _repository.IndexMaterialPlayer = index;
        _repository.Save();
    }

    public void InitColorEnemy(Color color, int index)
    {
        _repository.ColorBallEnemy = color;
        _repository.IndexMaterialEnemy = index;
        _repository.SaveEnemy();
    }

    //public void InitIndexPlayer(int index)
    //{
    //    _repository.IndexMaterialPlayer = index;
    //    _repository.Save();
    //}

    //public void InitIndexEnemy(int index)
    //{
    //    _repository.IndexMaterialEnemy = index;
    //    _repository.SaveEnemy();
    //}
}
