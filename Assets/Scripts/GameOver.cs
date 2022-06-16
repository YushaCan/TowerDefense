using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Controls the game is over or not
    public static bool isGameOver = false;
    // To stop the background music
    public GameObject musicManager;
    // To activate the restart and quit button when game is over
    public GameObject restartButton;
    public GameObject gameOverText;
    public GameObject quitButton;
    private void Update()
    {
        IsGameOver();
    }

    // What happens when the game is over
    void IsGameOver()
    {
        if (isGameOver)
        {
            musicManager.gameObject.SetActive(false);
            restartButton.gameObject.SetActive(true);
            gameOverText.gameObject.SetActive(true);
            quitButton.gameObject.SetActive(true);
        }
    }

    // If you want to restart the game, this function does this job.
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        isGameOver = false;
        StartTheGame.isGameActive = false;
    }
}
