using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswersController : MonoBehaviour
{
    private AnswerRepository _repository;
    private AnswerInteractor _interactor;
    [SerializeField] private List<Text> _answers;
    public static int NumberAnswer;

    private void Start()
    {
        _repository = new AnswerRepository();
        _interactor = new AnswerInteractor(_repository);
    }

    public void Initialized()
    {
        _repository.Initialize();
        _interactor.Initialize();
        AnswersInitialize();
    }

    private void AnswersInitialize()
    {
        int rightAnswer = Random.Range(0, _answers.Count);
        NumberAnswer = rightAnswer;
        _answers[rightAnswer].text = $"{_interactor.Answer}";
        for(int i = 0; i < _answers.Count; i++)
        {
            int fault = Random.Range(-30, 31);
            if (fault == 0)
                fault++;
            if (i != rightAnswer)
            {
                _answers[i].text = $"{_interactor.Answer + fault}";
            }
        }
    }
}
