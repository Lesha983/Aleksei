using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OneCell : MonoBehaviour
{
    [SerializeField] private Material _startMaterial;
    private ColorRepository _repository;
    private ColorInteractor _interactor;
    private Renderer _mat;
    private ColorMaterials _colorMaterials;

    public UnityEvent Move;

    private void Awake()
    {
        RoundController.RoundStart += StartRound;
        _colorMaterials = ColorMaterials.Initialization;
        _repository = new ColorRepository();
        _interactor = new ColorInteractor(_repository);
    }

    private void Start()
    {
        _mat = gameObject.GetComponent<Renderer>();
        StartRound();
    }

    private void Initialization()
    {
        _repository.Initialize();
        _interactor.Initialize();
    }

    private void StartRound()
    {
        _mat.material = _startMaterial;
        gameObject.tag = "Player";
        gameObject.GetComponent<SphereCollider>().enabled = true;
    }

    private void OnMouseDown()
    {
        if (RoundController.NextMovePlayer && !RoundController.GameOver)
        {
            Initialization();
            _mat.material = _colorMaterials.MaterialsPlayer[_interactor._indexPlayer];
            gameObject.tag = "Player1";
            RoundController.ChangeMove();
            Move.Invoke();
        }
    }
}
