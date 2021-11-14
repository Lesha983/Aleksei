using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelSelection : ButtonClick
{
    [SerializeField] private float _rotateCamera;
    [SerializeField] private GameObject _enemy;
    [SerializeField] private GameObject _levelPanel;
    public UnityEvent StartRound;

    public override void Action()
    {
        StartRound.Invoke();
        Invoke("PlayGround", 2f);
    }

    private void PlayGround()
    {
        Camera.main.transform.eulerAngles = new Vector3(0, _rotateCamera, 0);
        _enemy.SetActive(true);
        _levelPanel.SetActive(false);
    }

    public void HomeGround()
    {
        Camera.main.transform.eulerAngles = new Vector3(0, 0, 0);
        _enemy.SetActive(false);
    }
}
