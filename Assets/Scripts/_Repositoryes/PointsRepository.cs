using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsRepository : Repository
{
    private const string _keyRecord = "Points";
    private const string _keyCurrent = "CurrentPoints";
    public int PointsRecord;
    public int CurrentPoints;

    public override void Initialize()
    {
        PointsRecord = PlayerPrefs.GetInt(_keyRecord);
        CurrentPoints = PlayerPrefs.GetInt(_keyCurrent);
    }

    public override void Save()
    {
        PlayerPrefs.SetInt(_keyRecord, PointsRecord);
    }

    public void CurrentPointSave()
    {
        PlayerPrefs.SetInt(_keyCurrent, CurrentPoints);
    }
}
