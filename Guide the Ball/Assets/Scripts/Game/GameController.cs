using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

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

    public void AddStar()
    {
        starCount++;
        audio.clip = pickupStar;
        audio.Play();
    }

    public void Finish()
    {
        timer = false;
        for (int i = 0; i < starCount; i++)
        {
            Stars[i].sprite = star;
        }

        int highscore = PlayerPrefs.GetInt("L1");

        if (starCount > highscore)
        {
            PlayerPrefs.SetInt("L1", starCount);
        }

        audio.clip = finish;
        audio.Play();
        winCanvas.SetActive(true);
    }

    public void LoseGame()
    {
        loseCanvas.SetActive(true);
    }

    public void StartTimer()
    {
        timerCanvas.SetActive(true);
        timer = true;
    }
}
