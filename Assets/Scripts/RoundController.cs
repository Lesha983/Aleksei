using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundController : MonoBehaviour
{ 
    public static bool NextMovePlayer, GameOver;
    private ColorRepository _repository;
    private ColorInteractor _interactor;
    public delegate void Start();
    public static Start RoundStart;
    [Header("Start")]
    [SerializeField] private GameObject _roundAnim;
    [SerializeField] private Image _triangleUp, _triangleDown;
    private Animation _startRoundAnim;
    [Header("GameOver")]
    [SerializeField] private GameObject _goPanel;
    [SerializeField] private Text _result;
    private enum results { Win, Lose, Draw }

    private void Awake()
    {
        _startRoundAnim = _roundAnim.GetComponent<Animation>();
        _repository = new ColorRepository();
        _interactor = new ColorInteractor(_repository);
        Initialization();
    }

    public void CheckCombination(int count)
    {
        if (count == 3)
        {
            _result.text = $"{results.Win}";
            RoundEnd();
        }
        if (count == -3)
        {
            _result.text = $"{results.Lose}";
            RoundEnd();
        }
        if (count == 0)
        {
            _result.text = $"{results.Draw}";
            RoundEnd();
        }
    }

    public static void ChangeMove()
    {
        NextMovePlayer = !NextMovePlayer;
    }

    private void Initialization()
    {
        _repository.Initialize();
        _interactor.Initialize();
    }

    private void ChangeTrianglesColor()
    {
        Initialization();
        _triangleDown.color = _interactor._colorPlayer;
        _triangleUp.color = _interactor._colorEnemy;
    }


    public void StartRound()
    {
        NextMovePlayer = (Random.Range(0, 2) == 0) ? true : false;
        GameOver = false;
        ChangeTrianglesColor();
        if (NextMovePlayer)
        {
            _startRoundAnim.Play("TriangleDown");
            _roundAnim.GetComponent<Image>().color = _interactor._colorPlayer;
            print("Down");
        }
        else
        {
            _startRoundAnim.Play("TriangleUp");
            _roundAnim.GetComponent<Image>().color = _interactor._colorEnemy;
            print("Up");
        }
        RoundStart?.Invoke();
    }

    private void RoundEnd()
    {
        _goPanel.SetActive(true);
        GameOver = true;
    }

    public void GOPanelOff()
    {
        _goPanel.SetActive(false);
    }
}
