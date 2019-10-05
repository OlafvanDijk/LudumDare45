using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private List<Image> Stars;

    [SerializeField]
    private Sprite star;

    [SerializeField]
    private GameObject winCanvas;

    [SerializeField]
    private GameObject loseCanvas;

    [SerializeField]
    private AudioClip pickupStar;

    [SerializeField]
    private AudioClip finish;

    [SerializeField]
    private AudioSource audio;

    private int starCount;

    public void AddStar()
    {
        starCount++;
        audio.clip = pickupStar;
        audio.Play();
    }

    public void Finish()
    {
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
}
