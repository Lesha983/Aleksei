using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsMenu : MonoBehaviour
{
    [SerializeField] private GameObject _titre, _recordList;
    [SerializeField] private List<Text> _recordsTxt;
    [SerializeField] private Sound _audio;
    private AudioSource _tapButton;
    public Titre TitreScript;
    private StartAndEndGame _startEnd;

    private void Start()
    {
        
        _tapButton = GetComponent<AudioSource>();
        _startEnd = StartAndEndGame.Instance;
    }

    public void StartGame()
    {
        _startEnd.StartGame();
    }

    public void RecordList()
    {
        for (int i = 0; i < _recordsTxt.Count; i++)
        {
            _recordsTxt[i].text = PlayerPrefs.GetInt($"{i}").ToString();
        }
        _recordList.SetActive(true);
    }

    public void Titre()
    {
        _titre.SetActive(true);
        TitreScript.StartScript();
        _audio.Titre();
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Audio()
    {
        _tapButton.Play();
    }
}
