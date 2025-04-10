using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using System;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text textScore;
    public GameObject gameOverScreen;
    public int highScore;
    public Text textHighScore;

    void Start()
    {
        highScore = PlayerPrefs.GetInt("highScore");
        textHighScore.text = highScore.ToString();
    }




    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        if (String.IsNullOrEmpty(PlayerPrefs.GetInt("highScore").ToString()))
        {
            PlayerPrefs.SetInt("highScore", 0);
        }

        highScore = PlayerPrefs.GetInt("highScore");

        playerScore = playerScore + scoreToAdd;
        textScore.text = playerScore.ToString();
        if(playerScore>highScore) { 
            PlayerPrefs.SetInt("highScore", playerScore);
        }
        highScore = PlayerPrefs.GetInt("highScore");
        textHighScore.text = highScore.ToString();
        
    }

    

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
    }

}
