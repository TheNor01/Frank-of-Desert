using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public GameObject scoreObject;
    // private Text actualText;
    private int score;
    private Text newText;
    private void Start()
    {
        instance = this;
        score = 0;
     
    }

    public void updateText(int scorePoint)
    {
        score += scorePoint;
        scoreObject.GetComponent<Text>().text = score.ToString();

    }

    public int getScore()
    {
        Debug.Log("Score" + score);
        return score;
    }
}

