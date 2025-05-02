using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;

    private Vector3 velocity = Vector3.zero;

    public void Move(Vector3 _velocity)
    {
        velocity = _velocity;
    }

    private void PerformMovement()
    {
        if (velocity != Vector3.zero) {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
    }

    private void FixedUpdate()
    {
        PerformMovement();
    }
}
