using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    private Text _txt;
    private int _currentPoints;

    private PointsRepository _repository;
    private PointsInteractor _interactor;

    public static int CountPoint;

    private void Start()
    {
        _txt = GetComponent<Text>();
        _currentPoints = 0;
        CountPoint = 0;
        _txt.text = $"{_currentPoints}";
        _repository = new PointsRepository();
        _interactor = new PointsInteractor(_repository);
    }

    public void PointUpdate()
    {
        Initialization();
        _currentPoints += CountPoint;
        _txt.text = $"{_currentPoints}";
    }

    public void Reset()
    {
        _currentPoints = 0;
        _txt.text = $"{_currentPoints}";
    }

    public void GameOver()
    {
        Initialization();
        _interactor.NewRecord(_currentPoints);
    }

    private void Initialization()
    {
        _repository.Initialize();
        _interactor.Initialize();
    }
}
