using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTracker : MonoBehaviour
{

    public Transform player;
    public float startingPosition;
    public float score;
    public Text scoreText;

    void Start()
    {
        startingPosition = player.position.y;
        score = 0f;
    }

    void Update()
    {
        float distanceTravelled = player.position.y - startingPosition;
        score = distanceTravelled * 10f;
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score.ToString("0");
    }
}
