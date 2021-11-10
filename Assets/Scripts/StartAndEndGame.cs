using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class StartAndEndGame : MonoBehaviour
{
    public static StartAndEndGame Instance;
    public delegate void GameOverDelegate();
    public static GameOverDelegate GameOver;
    [Header("Старт Игры")]
    [SerializeField] private List<GameObject> _uiMain;
    [SerializeField] private List<GameObject> _uiStartGame;
    private MonsterSpawner _spawner;
    [Header("Конец Игры")]
    [SerializeField] private List<int> _newRecords;
    [SerializeField] private List<GameObject> _monsters;
    [SerializeField] private GameObject _panelGameOver;
    [SerializeField] private List<Text> _recordsTxt;
    public List<int> Records;
    private int _numberOfRecords = 5;

    public void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        GameOver += SortingRecords;
        GameOver += Stats.Replay;

         _spawner = MonsterSpawner.Instance;
        for (int i = 0; i < _numberOfRecords; i++)
        {
            Records.Add(PlayerPrefs.GetInt($"{i}"));
        }
    }

    public void StartGame ()
    {
        foreach (GameObject ui in _uiMain)
        {
            ui.SetActive(false);
        }

        foreach (GameObject ui in _uiStartGame)
        {
            ui.SetActive(true);
        }
        Camera.main.GetComponent<Animation>().Play();
        GameObject.FindGameObjectWithTag("Island").GetComponent<Island>().enabled = false;
        _spawner.StartGame();
    }

    public void EndGame()
    {
        Records.Add(Stats.Score);
        if (Records.Count > _numberOfRecords)
        {
            Records.Remove(Records.Min());
        }
        GameOver?.Invoke();
        _panelGameOver.SetActive(true);
        _monsters.AddRange(GameObject.FindGameObjectsWithTag("Monster"));
        foreach (GameObject monster in _monsters)
        {
            Destroy(monster);
        }
    }

    public void SortingRecords()
    {
        var NewRecords = Records.OrderByDescending(rec => rec).Distinct();
        if (NewRecords.Count() < _numberOfRecords)
        {
            foreach (int i in NewRecords)
            {
                _newRecords.Add(i);
            }
            for (int i = 0; i < _numberOfRecords; i++)
            {
                _newRecords.Add(0);
            }
        }
        else
        {
            foreach (int i in NewRecords)
            {
                _newRecords.Add(i);
            }
        }
        for (int i = 0; i < _recordsTxt.Count; i++)
        {
            PlayerPrefs.SetInt($"{i}", _newRecords[i]);
        }
        _newRecords.Clear();
    }
}
