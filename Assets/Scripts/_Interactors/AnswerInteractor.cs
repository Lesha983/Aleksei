using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerInteractor : Interactor
{
    private AnswerRepository _repository;
    public int Answer => _repository.Answer;

    public AnswerInteractor(AnswerRepository repository)
    {
        _repository = repository;
    }

    public void NewAnswer(int value)
    {
        _repository.Answer = value;
        _repository.Save();
    }

    public bool RightAnswer(int value)
    {
        if (value == _repository.Answer)
            return true;
        return false;
    }
}
