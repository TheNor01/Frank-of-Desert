using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Save
{

    public static void SaveScore(int score)
    {
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.Save();
    }

    public static int GetScore()
    {
        return PlayerPrefs.GetInt("Score");
    }
}