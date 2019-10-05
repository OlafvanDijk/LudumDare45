using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OutOfBounds : MonoBehaviour
{

    [Header("Events")]
    [SerializeField]
    private UnityEvent OutOfBoundsEvent;

    private bool finish;

    /// <summary>
    /// Invoke event, Destroy player
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (finish == false)
        {
            if (other.CompareTag("Player"))
            {
                OutOfBoundsEvent.Invoke();
                Destroy(other.gameObject);
            }
        }
    }

    /// <summary>
    /// Player has finished stop doing anything
    /// </summary>
    public void Finish()
    {
        finish = true;
    }
}
