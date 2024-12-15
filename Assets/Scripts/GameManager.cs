using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    int score;
    bool gameOver = false;
    public TextMeshProUGUI scoreText;
    public GameObject livesHolder;
    public GameObject gameOverPanel;
    int lives = 4;
    
    void Awake()
    {
        instance = this;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncrementScore()
    {
       if(!gameOver)
       {
            score++;
            scoreText.text = score.ToString();
        }
    }

    public void DecreaseLife()
    {
        if(lives > 0)
        {
            lives--;
            livesHolder.transform.GetChild(lives).gameObject.SetActive(false);
        }

        if(lives <= 0 || score < 0)
        {
            gameOver = true;
            GameOver();
        }
    }

    public void DecrementScore()
    {
        if(!gameOver)
        {
            score--;
            scoreText.text = score.ToString();
        }
    }

    public void GameOver()
    {
        CandySpawner.instance.StopSpawningCandies();
        LeafSpawner.instance.StopSpawningLeaves();
        GameObject.Find("Player").GetComponent<PlayerMovement>().canMove = false;
        gameOverPanel.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
