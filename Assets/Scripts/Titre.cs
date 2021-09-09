using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Titre : MonoBehaviour
{
    [SerializeField] private List<Sprite> _sprites;
    [SerializeField] private GameObject _panel;
    [SerializeField] private GameObject _backGround;
    [SerializeField] private int _checkPos;
    [SerializeField] private int _time;
    [SerializeField] private int _speed;
    private RectTransform rec;
    private Image _sprite;

    public void StartScript()
    {
        _sprite = _backGround.GetComponent<Image>();
        rec = _panel.GetComponent<RectTransform>();
        StartCoroutine(ChangeSprite());
        rec.offsetMin = new Vector2(rec.offsetMin.x, -392);
        rec.offsetMax = new Vector2(rec.offsetMax.x, -392);
    }

    IEnumerator ChangeSprite()
    {
        int i = 0;
        while (true)
        {
            _sprite.sprite = _sprites[i];
            yield return new WaitForSeconds(_time);
            if (i < _sprites.Count - 1)
                i++;
        }
    }

    private void Update()
    {
        if (rec.offsetMin.y != _checkPos)
        {
            rec.offsetMin += new Vector2(rec.offsetMin.x, _speed);
            rec.offsetMax += new Vector2(rec.offsetMax.x, _speed);
        }
    }
}
