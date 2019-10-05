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

    private float starCount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddStar()
    {
        starCount++;
    }

    public void Finish()
    {
        for (int i = 0; i < starCount; i++)
        {
            Stars[i].sprite = star;
        }

        winCanvas.SetActive(true);
    }

    public void LoseGame()
    {
        loseCanvas.SetActive(true);
    }
}
