using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;
using TMPro;
using System;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public GameObject pointPrefab;
    public GameObject currentPointObject;

    public Transform[] pointPositions;
    int previousPos;
    public Dreamlo scoreManager;

    int score;

    float timer;
    bool gameActive;

    public TMP_Text timeText;
    public TMP_Text scoreText;

    public TMP_Text bestScore;
    public TMP_Text globalScore;

    private void Update()
    {
        if (gameActive)
        {
            timer -= Time.deltaTime;
            timeText.text = "Time: " + timer.ToString("00");
            if (timer <= 0)
                EndGame();
        }
        else
        {
            GamePadState state = GamePad.GetState(0);
            if(state.Buttons.A == ButtonState.Pressed)
            {
                ResetGame();
                gameActive = true;
            }
        }
    }

    private void Start()
    {
        if (instance == null)
            instance = this;
    }

    void ResetGame()
    {
        score = 0;
        scoreText.text = "Score: 00";

        if (currentPointObject != null)
            Destroy(currentPointObject);

        SpawnNewPoint();
        timer = 60f;
        timeText.text = "Time: 60";
    }

    public void ScorePoint()
    {
        score++;
        scoreText.text = "Score: " + score.ToString("00");
        SpawnNewPoint();
    }

    void SpawnNewPoint()
    {
        int newPos = UnityEngine.Random.Range(0, pointPositions.Length);

        if (newPos == previousPos)
            newPos++;

        if (newPos >= pointPositions.Length)
            newPos = 0;

        currentPointObject = Instantiate(pointPrefab, pointPositions[newPos].position, Quaternion.identity);
    }

    void EndGame()
    {
        gameActive = false;

        int highscore = PlayerPrefs.GetInt("Highscore", 0);

        if (score > highscore)
        {
            PlayerPrefs.SetInt("Highscore", score);
            scoreManager.AddNewHighscore(Environment.UserName, score);
        }

        bestScore.text = "Best: " + PlayerPrefs.GetInt("Highscore", 0).ToString("00");
        scoreManager.DownloadHighscores();
    }
}
