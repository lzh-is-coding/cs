using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;

    [SerializeField]
    private PlayerController controller;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xMove = Input.GetAxisRaw("Horizontal");
        float yMove = Input.GetAxisRaw("Vertical");

        Vector3 velocity = (transform.right * xMove + transform.forward * yMove).normalized * speed;

        controller.Move(velocity);
    }
}
