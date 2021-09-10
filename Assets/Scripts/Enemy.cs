using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private int _healsPoint = 10;
    [SerializeField] private float _speed = 3;
    [SerializeField] private int _speedRotation = 2;
    [SerializeField] private int _scorePoint;
    [SerializeField] private GameObject _freezBomb;
    [SerializeField] private GameObject _explosiveBomb;
    private AudioSource _audio;
    private Animator _animator;
    private UIStats _ui;
    private StartAndEndGame _startEnd;
    private Vector3 _destination;
    private int _currentHeals;
    private float _timer;
    
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _audio = GetComponent<AudioSource>();
        _ui = UIStats.Instance;
        _startEnd = StartAndEndGame.Instance;
        //_ui._monstersLives.Add(gameObject);
        Initialization();
        BombExplosive.BombActive += DiedMonster;
        if (Stats.GameOver)
        {
            _startEnd.EndGame();
        }
        InitDest();
    }

    private void Initialization()
    {
        _currentHeals = _healsPoint + Stats.Level * 2;
        _speed += Stats.Level / 2f;
        _timer = 0.5f;
        ++Stats.AmountMonsters;
        _ui.UpdateStats();
    }

    private void Update()
    {
        Move();
        Rotation(_destination);
        if (transform.position == _destination)
            InitDest();
    }

    protected virtual void OnMouseDown()
    {
        if (_currentHeals > 0)
        {
            _currentHeals -= 5;
            _animator.SetTrigger("TakeDamage");
        }
        else
        {
            DiedMonster();
            GetComponent<BoxCollider>().enabled = false;
        }
    }

    public virtual void DiedMonster()
    {
        _animator.SetTrigger("Die");
        _audio.Play();
        BombExplosive.BombActive -= DiedMonster;
        //_ui._monstersLives.Remove(gameObject);
        Destroy(gameObject, 1f);
        Stats.Score += _scorePoint;
        --Stats.AmountMonsters;
        _ui.UpdateStats();
        Boost();
    }

    private void Boost()
    {
        float _chanceBoost = Random.Range(0f, 1f);
        if (_chanceBoost >= 0.9f)
        {
            Instantiate(_freezBomb, gameObject.transform.position, Quaternion.identity);
        }
        else if (_chanceBoost <= 0.87f)
        {
            Instantiate(_explosiveBomb, gameObject.transform.position, Quaternion.identity);
        }
    }

    protected void Move()
    {
        _animator.SetBool("Run", true);
        transform.position = Vector3.MoveTowards(transform.position, _destination, Time.deltaTime * _speed);
    }

    protected void InitDest() //новые координаты для точки назначения
    {
        if (_timer <= 0)
        {
            _destination = new Vector3(Random.Range(-15, 15), 0.6f, Random.Range(-12, 12));
            _timer = 0.5f;
        }
        else
        {
            _timer -= Time.deltaTime;
        }
    }

    private void Rotation(Vector3 target)
    {
        Vector3 deltaPosition = target - transform.position;
        float angleY = Mathf.Atan2(deltaPosition.x, deltaPosition.z) * Mathf.Rad2Deg;
        Quaternion angle = Quaternion.Euler(0f, angleY, 0f);
        transform.rotation = Quaternion.Lerp(transform.rotation, angle, Time.deltaTime * _speedRotation);
    }
}
