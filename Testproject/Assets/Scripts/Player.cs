using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody rigidbody;
    private Vector3 direction;

    private void Update()
    {
        direction = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            direction = Vector3.forward;
        }

        rigidbody.velocity = direction * speed;
    }
}
