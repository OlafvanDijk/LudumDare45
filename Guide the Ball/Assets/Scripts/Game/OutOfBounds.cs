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

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.tag);
        if (finish == false)
        {
            if (other.CompareTag("Player"))
            {
                OutOfBoundsEvent.Invoke();
                Destroy(other.gameObject);
            }
        }
    }

    public void Finish()
    {
        finish = true;
    }
}
