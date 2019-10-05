using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Star : MonoBehaviour
{

    [SerializeField]
    private UnityEvent CollectStar;

    /// <summary>
    /// Invoke event, Destroy star
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CollectStar.Invoke();
            Destroy(this.gameObject);
        }
    }
}
