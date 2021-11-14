using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerRepository : Repository
{
    private const string _key = "Answer";
    public int Answer;

    public override void Initialize()
    {
        Answer = PlayerPrefs.GetInt(_key, 0);
    }

    public override void Save()
    {
        PlayerPrefs.SetInt(_key, Answer);
    }
}
