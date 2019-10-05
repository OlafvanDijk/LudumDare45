using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnFreezeBall : MonoBehaviour
{

    [SerializeField]
    private Rigidbody2D rigidbody;

    private bool used;

    // Update is called once per frame
    void Update()
    {
        if (used == false)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                used = true;
                rigidbody.bodyType = RigidbodyType2D.Dynamic;
            }
        }
    }
}
