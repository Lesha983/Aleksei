using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Record : MonoBehaviour
{
    private Text _txt;

    private PointsRepository _repository;
    private PointsInteractor _interactor;

    private void Start()
    {
        _txt = GetComponent<Text>();

        _repository = new PointsRepository();
        _interactor = new PointsInteractor(_repository);
        Initialization();

        _txt.text = $"{_interactor.PointsRecord}";
    }

    public void UpdateRecord()
    {
        _txt.text = $"{_interactor.PointsRecord}";
    }

    private void Initialization()
    {
        _repository.Initialize();
        _interactor.Initialize();
    }

}
