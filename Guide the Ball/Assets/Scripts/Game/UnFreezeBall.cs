using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnFreezeBall : MonoBehaviour
{

    [SerializeField]
    private Rigidbody2D rigidbody;

    [Header("Events")]
    [SerializeField]
    private UnityEvent StartTimer;

    private bool used;

    // Update is called once per frame
    void Update()
    {
        if (used == false)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                used = true;
                StartTimer.Invoke();
                rigidbody.bodyType = RigidbodyType2D.Dynamic;
            }
        }
    }
}
