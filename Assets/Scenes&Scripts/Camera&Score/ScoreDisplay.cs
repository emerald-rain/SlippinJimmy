using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    public GameObject player;
    public TextMesh scoreTextMesh;
    public float scoreMultiplier = 1;
    private float initialYPosition;
    private float highestYPosition;
    private int score;

    void Start()
    {
        initialYPosition = player.transform.position.y;
        highestYPosition = initialYPosition;
        score = 0;
        UpdateScoreText();
    }

    void Update()
    {
        if (player.transform.position.y > highestYPosition)
        {
            highestYPosition = player.transform.position.y;
            score = Mathf.FloorToInt((highestYPosition - initialYPosition) * scoreMultiplier);
            UpdateScoreText();
        }
    }

    void UpdateScoreText()
    {
        scoreTextMesh.text = "Score: " + score.ToString();
    }
}
