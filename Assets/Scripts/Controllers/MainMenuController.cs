using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public Text bestScore;

    void Start()
    {
        bestScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString("00");
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}
