using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    private float spawnRate = 1.0f;

    private int score;
    public int lives;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI livesText;

    public bool isGameActive;
    public Button restartButton;
    public GameObject titleScreen;

    public GameObject pauseScreen;
    public bool paused;
    // Start is called before the first frame update
    public void StartGame(int difficulty)
    {
        isGameActive = true;
        StartCoroutine(SpawnTarget());
        score = 0;
        lives = 3;
        UpdateScore(0);
        UpdateLives(0);
        titleScreen.gameObject.SetActive(false);
        spawnRate /= difficulty;
    }

    void ChangePaused()
    {
        if (!paused)
        {
            paused = true;
            pauseScreen.SetActive(true);
            Time.timeScale = 0; // pause all physics calculations
        }
        else
        {
            paused = false;
            pauseScreen.SetActive(false);
            Time.timeScale = 1;

        }
    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
            //UpdateScore(5);
        }
    }

    void Update()
    {
        //Check if the user has pressed the P key
        if (Input.GetKeyDown(KeyCode.P))
        {
            ChangePaused();
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
        if (score < 0)
            GameOver();
    }

    public void UpdateLives(int lifeToAdd)
    {
        lives += lifeToAdd;
        livesText.text = "Lives: " + lives;
        if (lives <= 0)
            GameOver();
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
