using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Finish : MonoBehaviour {

    [SerializeField]
    [Range(0,5)]
    private float minFinishTime;

    [Header("Events")]
    [SerializeField]
    private UnityEvent FinishEvent;

    /// <summary>
    /// Start Timer
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(FinishTimer());
        }
    }

    /// <summary>
    /// Stop all running coroutines.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StopAllCoroutines();
        }
    }

    /// <summary>
    /// When finished invoke event.
    /// </summary>
    /// <returns></returns>
    private IEnumerator FinishTimer()
    {
        yield return new WaitForSecondsRealtime(minFinishTime);
        FinishEvent.Invoke();
    }
}
