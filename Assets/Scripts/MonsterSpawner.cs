using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public static MonsterSpawner Instance;
    [SerializeField] private List<GameObject> _monsters;
    [SerializeField] private float _spawnTime;
    [SerializeField] private GameObject _animationStart;
    public static bool freez;
    private bool _stopCoroutine;

    public void Awake()
    {
        Instance = this;
        //StartAndEndGame.GameStart += StartGame;
    }

    public void StartGame()
    {
        freez = true;
        _stopCoroutine = true;
        StartCoroutine(MonstersSpawner());
        StartAndEndGame.GameOver += EndGame;
    }

    IEnumerator MonstersSpawner()
    {
        yield return new WaitForSeconds(1f);
        while (_stopCoroutine)
        {
            if (freez == true)
            {
                float _spawnController = Stats.Level * 0.25f;
                if (_spawnController < 3)
                {
                    _spawnTime = Random.Range(2f, 5 - _spawnController);
                }
                else
                {
                    _spawnTime = 2;
                }
                Vector3 spawnPosition = new Vector3(Random.Range(-15f, 15f), 0.5f, Random.Range(-15f, 15f));
                Instantiate(_animationStart, spawnPosition, Quaternion.identity);
                //Destroy(_animationStart, 2f);
                yield return new WaitForSeconds(0.5f);
                Instantiate(_monsters[Random.Range(0, _monsters.Count)], spawnPosition, Quaternion.identity);
                yield return new WaitForSeconds(_spawnTime);
            }
            else
            {
                yield return new WaitForSeconds(3f);
                freez = true;
            }
        }
    }

    public void EndGame()
    {
        //StopCoroutine(MonstersSpawner());
        _stopCoroutine = false;
        print("Stop");
    }
}
