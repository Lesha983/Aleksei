using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ExampleTxt : MonoBehaviour
{
    private AnswerRepository _repository;
    private AnswerInteractor _interactor;

    private TextMeshPro _txt;
    [SerializeField] private UnityEvent StartRound;

    private void Start()
    {
        _repository = new AnswerRepository();
        _interactor = new AnswerInteractor(_repository);
        _txt = GetComponent<TextMeshPro>();
        _txt.text = $"Play";
    }

    private void OnMouseDown()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        StartRound.Invoke();
    }

    public void ChoisceExample()
    {
        _repository.Initialize();
        _interactor.Initialize();

        int randomExample = Random.Range(0, 5);
        switch(randomExample)
        {
            case 0:
                ExampleWithPlus();
                break;
            case 1:
                ExampleWithMinus();
                break;
            case 2:
                DivisionExample();
                break;
            default:
                MultiplicationExample();
                break;
        }
    }

    private void ChangeExample(string example, int result)
    {
        _txt.text = example;
        _interactor.NewAnswer(result);
    }

    public void ExampleWithPlus()// a+b
    {
        int a = Random.Range(0, 101);
        int b = Random.Range(0, 101);
        string _example = $"{a}+{b}";
        int _result = a + b;
        Points.CountPoint = 1;
        ChangeExample(_example, _result);
    }

    public void ExampleWithMinus()// a-b
    {
        int a = Random.Range(0, 101);
        int b = Random.Range(0, 101);
        string _example = $"{a}-{b}";
        int _result = a - b;
        Points.CountPoint = 2;
        ChangeExample(_example, _result);
    }

    public void DivisionExample() // a/b
    {
        int a = Random.Range(-100, 500);
        int b = Random.Range(1, 15);
        if (a % b == 0)
        {
            string _example = $"{a}/{b}";
            int _result = a / b;
            Points.CountPoint = 4;
            ChangeExample(_example, _result);
        }
        else
            DivisionExample();
    }

    public void MultiplicationExample() // a*b
    {
        int a = Random.Range(-35, 36);
        int b = Random.Range(-15, 16);
        string _example = $"{a}*{b}";
        int _result = a * b;
        Points.CountPoint = 3;
        ChangeExample(_example, _result);
    }
}
