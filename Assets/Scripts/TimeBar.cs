using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.Events;

public class TimeBar : MonoBehaviour
{
    private RectTransform _rec;
    private Color _colorStart, _colorEnd;
    private Image _color;

    public float Time;
    public UnityEvent gameOver;

    private void Start()
    {
        _rec = GetComponent<RectTransform>();
        _colorStart = new Color(0.1f, 0.75f, 0.13f);
        _colorEnd = new Color(0.75f, 0.13f, 0.1f);
        _color = GetComponent<Image>();
        Timer();
    }

    private void FixedUpdate()
    {
        if(_rec.anchorMax.x == 0)
        {
            GameOver();
        }
    }

    public void RestartTimer()
    {
        _rec.DOAnchorMax(new Vector2(1, 1), 0, false);
        _color.DOColor(_colorStart, 0);
        Timer();
    }

    private void Timer()
    {
        _rec.DOAnchorMax(new Vector2(0, 1), Time, false);
        _color.DOColor(_colorEnd, Time);
    }

    public void GameOver()
    {
        gameOver.Invoke();
        gameObject.SetActive(false);
    }
}
