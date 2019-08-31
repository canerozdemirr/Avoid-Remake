using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("GameOver/Pause")]
    public GameObject gameOverPanel;
    public Text scoreText, highScoreText;
    public Button resume;

    [Header("InGame")]
    public Text scoreTextInGame;
    private int score;

    private bool gameOver;
    public bool isDead;

    void Awake()
    {
        instance = this;
        Time.timeScale = 1;
        SoundManager.instance.PlayGameMusic();
    }

    void Update()
    {
        if(!gameOver && isDead)
        {
            gameOver = true;
            StartCoroutine(GameOver());
        }
    }

    public void IncreseScore()
    {
        score++;
        scoreTextInGame.text = score.ToString("00");
    }

    IEnumerator GameOver()
    {
        SoundManager.instance.PlayGameOverMusic();
        yield return new WaitForSeconds(1);
        Time.timeScale = 0;

        gameOverPanel.SetActive(true);

        scoreText.text = score.ToString("00");

        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }

        highScoreText.text = PlayerPrefs.GetInt("HighScore").ToString("00");

        resume.onClick.AddListener(() => RestartButton());
        resume.transform.GetChild(0).GetComponent<Text>().text = "RESTART";
    }

    public void PauseButton()
    {
        SoundManager.instance.PlayUIClick();
        Time.timeScale = 0;

        gameOverPanel.SetActive(true);

        scoreText.text = score.ToString("00");

        if(score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }

        highScoreText.text = PlayerPrefs.GetInt("HighScore").ToString("00");

        resume.onClick.AddListener(() => ResumeButton());
        resume.transform.GetChild(0).GetComponent<Text>().text = "RESUME";
    }

    public void ResumeButton()
    {
        SoundManager.instance.PlayUIClick();
        Time.timeScale = 1;
        gameOverPanel.SetActive(false);
    }

    public void RestartButton()
    {
        SoundManager.instance.PlayUIClick();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
