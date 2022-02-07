using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


    

    public class ScoreController : MonoBehaviour
{
    private TextMeshProUGUI scoreUI;

    private int score = 0;
    private void Awake()
    {
        scoreUI = gameObject.GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
        RefreshScore();
    }

    public void ScoreIncrement(int increment)
    {
        score += increment;
        RefreshScore();
    }

    private void RefreshScore()
    {
        scoreUI.text = "Score: " + score;
    }
}
