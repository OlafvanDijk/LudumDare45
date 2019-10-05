using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLevel : MonoBehaviour
{
    [SerializeField]
    private string level;

    public void Select()
    {
        try
        {
            SceneManager.LoadScene(level);
        }
        catch (System.Exception)
        {
            Debug.Log("Scene doesn't exist");
        }
        
    }
}
