using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class UIStats : MonoBehaviour 
{
    public static UIStats Instance;
    [SerializeField] private Text _levelTxt;
    [SerializeField] private Text _scoreTxt;
    [SerializeField] private Text _amountMonstersTxt;

    public void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        StartAndEndGame.GameOver += UpdateStats;
    }

    public void UpdateStats()
    {
        _levelTxt.text = $"Level {Stats.Level}";
        _scoreTxt.text = Stats.Score.ToString();
        _amountMonstersTxt.text = $"{Stats.AmountMonsters}/10";
    }

}