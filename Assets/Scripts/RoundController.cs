using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoundController : MonoBehaviour
{
    [SerializeField] private List<GameObject> _uiPlayScene;
    [SerializeField] private List<GameObject> _uiStartScene;
    [SerializeField] private List<GameObject> _uiRestart;
    [SerializeField] private ParticleSystem _effect;

    private void Start()
    {
        _effect.Play();
    }

    public void StartRound()
    {
        foreach(GameObject ui in _uiPlayScene)
        {
            ui.SetActive(true);
        }
        foreach(GameObject ui in _uiStartScene)
        {
            ui.SetActive(false);
        }
        foreach (GameObject ui in _uiRestart)
        {
            ui.SetActive(false);
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene(0);
    }

    public void RestartRound()
    {
        foreach (GameObject ui in _uiRestart)
        {
            ui.SetActive(true);
        }
    }
}
