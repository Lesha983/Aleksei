using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorRepository : Repository
{
    private const string _keyPlayer = "ColorPlayer";
    private const string _keyEnemy = "ColorEnemy";

    private const string _keyPlayerIndex = "IndexPlayer";
    private const string _keyEnemyIndex = "IndexEnemy";

    public Color ColorBallPlayer;
    public Color ColorBallEnemy;
    public int IndexMaterialPlayer;
    public int IndexMaterialEnemy;

    public override void Initialize()
    {
        if (PlayerPrefs.GetString(_keyPlayer) != "" && PlayerPrefs.GetString(_keyEnemy) != "")
        {
            ColorBallPlayer = GetColorFromString($"{PlayerPrefs.GetString(_keyPlayer)}");
            ColorBallEnemy = GetColorFromString($"{PlayerPrefs.GetString(_keyEnemy)}");
        }
        else
        {
            PlayerPrefs.SetString(_keyPlayer, "0000FF");
            ColorBallPlayer = GetColorFromString($"{PlayerPrefs.GetString(_keyPlayer)}");

            PlayerPrefs.SetString(_keyPlayer, "FF1A40");
            ColorBallEnemy = GetColorFromString($"{PlayerPrefs.GetString(_keyEnemy)}");
        }
        IndexMaterialPlayer = PlayerPrefs.GetInt(_keyPlayerIndex);
        IndexMaterialEnemy = PlayerPrefs.GetInt(_keyEnemyIndex);
    }

    public override void Save()
    {
        PlayerPrefs.SetString(_keyPlayer, GetStringFromColor(ColorBallPlayer));
        PlayerPrefs.SetInt(_keyPlayerIndex, IndexMaterialPlayer);
    }

    public void SaveEnemy()
    {
        PlayerPrefs.SetString(_keyEnemy, GetStringFromColor(ColorBallEnemy));
        PlayerPrefs.SetInt(_keyEnemyIndex, IndexMaterialEnemy);
    }

    private int HexToDec(string hex)
    {
        int dec = System.Convert.ToInt32(hex, 16);
        return dec;
    }

    private string DecToHex(int value)
    {
        return value.ToString("X2");
    }

    private float HexToFloatNormalized(string hex)
    {
        return HexToDec(hex) / 255f;
    }

    private string FloatNormalizedToHex(float value)
    {
        return DecToHex(Mathf.RoundToInt(value * 255f));
    }

    private Color GetColorFromString(string hexString)
    {
        float red = HexToFloatNormalized(hexString.Substring(0, 2));
        float green = HexToFloatNormalized(hexString.Substring(2, 2));
        float blue = HexToFloatNormalized(hexString.Substring(4, 2));
        return new Color(red, green, blue);
    }

    private string GetStringFromColor(Color color)
    {
        string red = FloatNormalizedToHex(color.r);
        string green = FloatNormalizedToHex(color.g);
        string blue = FloatNormalizedToHex(color.b);
        return red + green + blue;
    }
}
