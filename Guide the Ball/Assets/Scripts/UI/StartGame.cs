using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    [SerializeField]
    private GameObject levelSelect;

    public void StartGameButton()
    {
        levelSelect.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
