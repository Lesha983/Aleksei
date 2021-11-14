using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEasy : Enemy
{
    private ColorRepository _repository;
    private ColorInteractor _interactor;
    [SerializeField] ColorMaterials _colorMaterials;
    [SerializeField] RoundController _roundController;

    private int[] _intificationCell = new int[] {0,0,0,
                                                 0,0,0,
                                                 0,0,0};

    private Dictionary<int, int[]> _combo = new Dictionary<int, int[]>();//список всех победных комбинаций
    [SerializeField] private List<int> _changeMove;
    private bool _testLoss = false;

    private void Awake()
    {
        _repository = new ColorRepository();
        _interactor = new ColorInteractor(_repository);
        _repository.Initialize();
        _interactor.Initialize();
        _combo.Add(0, new int[] { 0, 1, 2 });
        _combo.Add(1, new int[] { 3, 4, 5 });
        _combo.Add(2, new int[] { 6, 7, 8 });
        _combo.Add(3, new int[] { 0, 3, 6 });
        _combo.Add(4, new int[] { 1, 4, 7 });
        _combo.Add(5, new int[] { 2, 5, 8 });
        _combo.Add(6, new int[] { 0, 4, 8 });
        _combo.Add(7, new int[] { 2, 4, 6 });
        RoundController.RoundStart += Start;
    }

    private void Start()
    {
        ResetInitializationCell();
        BallColor = _colorMaterials.MaterialsEnemy[_interactor._indexEnemy];
        if (!RoundController.NextMovePlayer)
        {
            FirstMove();
        }
    }

    public void StartRound()
    {
        InitializationCell();
        LossCombo();
        ThinkInAdvance();
    }

    public override void InitializationCell()
    {
        for (int i = 0; i < _intificationCell.Length; i++)
        {
            if (_allCell[i].tag == "Player1")
            {
                _intificationCell[i] = 1;
            }
            else if (_allCell[i].tag == "Player2")
            {
                _intificationCell[i] = -1;
            }
        }
    }

    private void ResetInitializationCell()
    {
        for (int i = 0; i < _intificationCell.Length; i++)
        {
            _intificationCell[i] = 0;
        }
    }

    private int LossCombo()
    {
        int x = 0;
        int _comboPlayer = 0;
        int _comboEnemy = 0;
        bool _result = false;
        foreach (KeyValuePair<int, int[]> keyValue in _combo)
        {
            for (int i = 0; i < keyValue.Value.Length; i++)
            {
                if (_intificationCell[keyValue.Value[i]] > 0)
                {
                    _comboPlayer++;
                }
                else if(_intificationCell[keyValue.Value[i]] < 0)
                {
                    _comboEnemy--;
                }
            }
            if (_comboPlayer == 3)
            {
                if (_testLoss)
                {
                    _roundController.CheckCombination(_comboPlayer);
                    _result = true;
                }
                else
                {
                    x = 10;
                }
                break;
            }
            else if (_comboEnemy == -3 && !_result)
            {
                if (_testLoss)
                {
                    _roundController.CheckCombination(_comboEnemy);
                    _result = true;
                }
                else
                {
                    x = -10;
                }
                break;
            }
            _comboPlayer = 0;
            _comboEnemy = 0;
        }
        if (_testLoss && !_result)
        {
            HaveSlot();
        }
        return x;
    }

    private void HaveSlot()
    {
        int _slot = 0;
        for (int i = 0; i < _intificationCell.Length; i++)
        {
            if (_intificationCell[i] == 0)
            {
                _slot++;
                break;
            }
        }
        if (_slot == 0)
        {
            _roundController.CheckCombination(0);
        }
    }

    private void ThinkInAdvance()
    {
        bool _moveCycle = false;
        _testLoss = false;
        for (int i = 0; i < _changeMove.Count; i++)
        {
            _changeMove[i] = 0;
        }
        for (int currentCell = 0; currentCell < _intificationCell.Length; currentCell++)
        {
            if (_intificationCell[currentCell] == 0)
            {
                _intificationCell[currentCell] = -1;
                LossCombo();
                if (LossCombo() == -10)
                {
                    if (_changeMove[0] == 0)
                    {
                        _changeMove[0] = currentCell;
                    }
                    _moveCycle = true;
                    break;
                }
                else
                {
                    if (_changeMove[1] == 0)
                    {
                        for (int currentCell2 = 0; currentCell2 < _intificationCell.Length; currentCell2++)
                        {
                            if (_intificationCell[currentCell2] == 0)
                            {
                                _intificationCell[currentCell2] = 1;
                                LossCombo();
                                if (LossCombo() == 10)
                                {
                                    if (_changeMove[1] == 0)
                                    {
                                        _changeMove[1] = currentCell2;
                                    }
                                    _moveCycle = true;
                                    _intificationCell[currentCell2] = 0;
                                    break;
                                }
                                else
                                {
                                    if (_changeMove[2] == 0)
                                    {
                                        for (int currentCell3 = 0; currentCell3 < _intificationCell.Length; currentCell3++)
                                        {
                                            if (_intificationCell[currentCell3] == 0)
                                            {
                                                _intificationCell[currentCell3] = -1;
                                                LossCombo();
                                                if (LossCombo() == -10)
                                                {
                                                    if (_changeMove[2] == 0)
                                                    {
                                                        _changeMove[2] = currentCell3;
                                                    }
                                                    _intificationCell[currentCell3] = 0;
                                                    _moveCycle = true;
                                                    break;
                                                }
                                                _intificationCell[currentCell3] = 0;
                                            }
                                        }
                                    }
                                }
                                _intificationCell[currentCell2] = 0;
                            }
                        }
                    }
                }
                _intificationCell[currentCell] = 0;
            }
        }
        if (_moveCycle)
        {
            ChangeMove();
        }
        else
        {
            UseBestMove();
        }
    }

    private void ChangeMove()
    {
        for (int i = 0; i < _changeMove.Count; i++)
        {
            if (_changeMove[i] != 0)
            {
                MakeAMove(_changeMove[i]);
                break;
            }
        }
    }

    private void UseBestMove()
    {
        List<int> _bestCell = new List<int>() { 0, 2, 4, 6, 8 };
        int _cellValue = 0;
        for (int i = 0; i < 6; i++)
        {
            int x = _bestCell[Random.Range(0, _bestCell.Count)];
            if (_bestCell.Count != 0)
            {
                if (_intificationCell[x] == 0)
                {
                    _cellValue = x;
                    break;
                }
                else
                {
                    _bestCell.Remove(_intificationCell[x]);
                }
            }
        }
        for (int i = 0; i < _intificationCell.Length; i++)
        {
            if (_intificationCell[i] == 0 && _cellValue == 0)
            {
                _cellValue = i;
                break;
            }
        }
        MakeAMove(_cellValue);
    }

    private void FirstMove()
    {
        List<int> _bestCell = new List<int>() { 0, 2, 4, 6, 8 };
        int x = _bestCell[Random.Range(0, _bestCell.Count)];
        MakeAMove(x);
    }

    private void MakeAMove(int index)
    {
        if (!RoundController.NextMovePlayer && !RoundController.GameOver)
        {
            _allCell[index].GetComponent<Renderer>().material = BallColor;
            _allCell[index].tag = "Player2";
            RoundController.ChangeMove();
            _testLoss = true;
            InitializationCell();
            LossCombo();
        }
    }
}
