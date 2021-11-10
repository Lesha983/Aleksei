using System.Collections;
using System.Collections.Generic;

public static class Stats 
{
    public static int Level { get; private set; }
    private static int _score = 0, levelcontroller = 100;
    private static int _amountMonsters;
    public static bool GameOver;
    private static int _maxCountMonstersInScene = 10;

    public static int Score
    {
        get
        {
            return _score;
        }
        set
        {
            _score = value;
            if(_score >= Level * levelcontroller)
            {
                Level++;
                levelcontroller += 50;
            }
        }
    }

    public static int AmountMonsters
    {
        get
        {
            return _amountMonsters;
        }
        set
        {
            _amountMonsters = value;
            if (_amountMonsters == _maxCountMonstersInScene)
            {
                GameOver = true;
            }
        }
    }

    public static void Replay()
    {
        Level = 1;
        _score = 0;
        _amountMonsters = 0;
        GameOver = false;
    }
}
