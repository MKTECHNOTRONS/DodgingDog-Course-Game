using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public ObstacleSpawner spawner;


    public GameObject gameOverPanel;
    public Text scoreText;

    private int score = 0;
    private bool gameOver = false;

    public float scoreInterval = 1f; // Time between score increments (in seconds)
    private float timer = 0f;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (!gameOver)
        {
            timer += Time.deltaTime;

            if (timer >= scoreInterval)
            {
                incrementScore();
                timer = 0f;
            }
        }
    }

    public void GameOver()
    {
        if (!gameOver)
        {
            gameOver = true;

            if (spawner != null)
            {
                spawner.StopSpawing();
            }
            else
            {
                Debug.LogWarning("Spawner not assigned in GameManager!");

            }
        }
        gameOverPanel.SetActive(true);
    }

    public void incrementScore()
    {
        score++;
        scoreText.text = score.ToString();
        Debug.Log("Score: " + score);
    }
    public void Restart()
    {
        SceneManager.LoadScene("Game");

    }
    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
