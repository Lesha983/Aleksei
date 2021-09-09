using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class StartAndEndGame : MonoBehaviour
{
    public static StartAndEndGame Instance;
    [Header("Старт Игры")]
    [SerializeField] private List<GameObject> _uiMain;
    [SerializeField] private List<GameObject> _uiStartGame;
    private MonsterSpawner _spawner;
    [Header("Конец Игры")]
    [SerializeField] private List<int> _newRecords;
    [SerializeField] private List<GameObject> _monsters;
    [SerializeField] private GameObject _panelGameOver;
    [SerializeField] private List<Text> _recordsTxt;
    private UIStats _ui;
    public List<int> Records;



    public void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _spawner = MonsterSpawner.Instance;
        _ui = UIStats.Instance;
        for (int i = 0; i < 5; i++)
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
        if (Records.Count > 5)
        {
            Records.Remove(Records.Min());
        }
        SortingRecords();
        _panelGameOver.SetActive(true);
        _spawner.EndGame();
        _monsters.AddRange(GameObject.FindGameObjectsWithTag("Monster"));
        foreach (GameObject monster in _monsters)
        {
            Destroy(monster);
        }
        Stats.Replay();
        _ui.UpdateStats();
    }

    public void SortingRecords()
    {
        var NewRecords = Records.OrderByDescending(rec => rec).Distinct();
        if (NewRecords.Count() < 5)
        {
            foreach (int i in NewRecords)
            {
                _newRecords.Add(i);
            }
            for (int i = 0; i < 5; i++)
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
