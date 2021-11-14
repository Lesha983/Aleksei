using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsInteractor : Interactor
{
    private PointsRepository _repository;
    public int PointsRecord => _repository.PointsRecord;
    public int CurrentPoints => _repository.CurrentPoints;

    public PointsInteractor(PointsRepository repository)
    {
        _repository = repository;
    }

    public void NewRecord(int value)
    {
        if (value > PointsRecord)
        {
            _repository.PointsRecord = value;
            _repository.Save();
        }
    }
    public void AddPoint(int value)
    {
        _repository.CurrentPoints += value;
        _repository.CurrentPointSave();
    }
}
