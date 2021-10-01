using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool isGameActive;

    [SerializeField] private Text scoreText;
    [SerializeField] private Text youWinText;
    [SerializeField] private GameObject postGameMenu;

    private int buildIndex;
    private int startingScore = 20;
    private int scoreLoss = 10;
    private int currentScore;

    void Awake()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        buildIndex = currentScene.buildIndex;
        isGameActive = true;
        if (currentScene.buildIndex == 1)
        {
            postGameMenu.SetActive(false);
            scoreText.text = "Score: " + startingScore.ToString();
        }
        currentScore = startingScore;
    }

    public void AddToScore(int scoreToAdd)
    {
        currentScore += scoreToAdd;
        if (currentScore >= 100)
        {
            isGameActive = false;
            postGameMenu.SetActive(true);
            youWinText.text = "You Win!";
        }

        scoreText.text = "Score: " + currentScore.ToString();
    }

    public void LoseScore()
    {
        currentScore -= scoreLoss;
        if (currentScore <= 0)
        {
            isGameActive = false;
            postGameMenu.SetActive(true);
            youWinText.text = "You Lose!";
        }

        scoreText.text = "Score: " + currentScore.ToString();
    }

    public void LoadTitleScene()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadMainScene()
    {
        isGameActive = true;
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
