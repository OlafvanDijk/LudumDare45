using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [Header("Game")]
    [SerializeField]
    private float timerCount = 60;

    [Header("Stars")]
    [SerializeField]
    private List<Image> Stars;

    [SerializeField]
    private Sprite star;
    
    [Header("Canvas")]
    [SerializeField]
    private GameObject winCanvas;

    [SerializeField]
    private GameObject loseCanvas;

    [SerializeField]
    private GameObject timerCanvas;

    [SerializeField]
    private TextMeshProUGUI timerText;

    [Header("Audio")]
    [SerializeField]
    private AudioClip pickupStar;

    [SerializeField]
    private AudioClip finish;

    [SerializeField]
    private AudioSource audio;

    private int starCount;
    
    private bool timer;

    /// <summary>
    /// Update timer
    /// </summary>
    private void Update()
    {
        if (timer)
        {
            timerCount -= Time.deltaTime;
            timerText.text = "Time: " + Math.Round(timerCount, 2);
            if (timerCount <= 0)
            {
                timer = false;
                timerCanvas.SetActive(false);
                LoseGame();
            }
        }
    }

    /// <summary>
    /// Call when a star has been collected
    /// </summary>
    public void AddStar()
    {
        starCount++;
        audio.clip = pickupStar;
        audio.Play();
    }

    /// <summary>
    /// Player has reached finish
    /// Disable timer
    /// Set stars
    /// Show canvas
    /// </summary>
    public void Finish()
    {
        timer = false;
        for (int i = 0; i < starCount; i++)
        {
            Stars[i].sprite = star;
        }
        string currentLvl = SceneManager.GetActiveScene().name;
        int highscore = PlayerPrefs.GetInt(currentLvl);

        if (starCount > highscore)
        {
            PlayerPrefs.SetInt(currentLvl, starCount);
        }

        audio.clip = finish;
        audio.Play();
        winCanvas.SetActive(true);
    }

    /// <summary>
    /// Activate Losing Canvas
    /// </summary>
    public void LoseGame()
    {
        timer = false;
        loseCanvas.SetActive(true);
    }

    /// <summary>
    /// Start Game Timer
    /// </summary>
    public void StartTimer()
    {
        timerCanvas.SetActive(true);
        timer = true;
    }
}
