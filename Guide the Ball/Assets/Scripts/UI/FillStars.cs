using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillStars : MonoBehaviour
{

    [SerializeField]
    private string prefName;

    [SerializeField]
    private List<Image> stars;

    [SerializeField]
    private Sprite star;

    // Start is called before the first frame update
    void Awake()
    {
        int starcount = PlayerPrefs.GetInt(prefName);
        for (int i = 0; i < starcount; i++)
        {
            stars[i].sprite = star;
        }
    }
}
