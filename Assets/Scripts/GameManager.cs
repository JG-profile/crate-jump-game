using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI gameOverText;
    private float score;
    private float lives;
    private float xRange = 10;
    public GameObject[] crates;
    private bool gameOver;
    public Button restartButton;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        lives = 3;
        scoreText.text = "Score: " + score;
        livesText.text = "Lives: " + lives;
        gameOver = false;
        StartCoroutine(SpawnCrates());
        StartCoroutine(UpdateScore());
    }


    IEnumerator SpawnCrates()
    {
        while (!gameOver)
        {
            yield return new WaitForSeconds(2);
            Vector3 position = new Vector3(Random.Range(-xRange, xRange), 14, -0.5f);
            GameObject crate = crates[Random.Range(0, crates.Length)];
            Instantiate(crate, position, crate.transform.rotation);
        }
    }

    IEnumerator UpdateScore()
    {
        while (!gameOver)
        {
            yield return new WaitForSeconds(1);
            score++;
            scoreText.text = "Score: " + (int)score;
        }
    }

    public void UpdateLives()
    {
        if (!gameOver)
        {
            lives--;
            livesText.text = "Lives: " + lives;
            if (lives == 0)
            {
                gameOverText.gameObject.SetActive(true);
                restartButton.gameObject.SetActive(true);
                gameOver = true;
            }
        }
        
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
