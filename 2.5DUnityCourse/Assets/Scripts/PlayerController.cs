using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int speed;

    private PlayerControls playerControls;
    private Rigidbody rigidbody;
    private Vector3 movement;

    private void Awake()
    {
        playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = playerControls.Player.Move.ReadValue<Vector2>().x;
        float z = playerControls.Player.Move.ReadValue<Vector2>().y;
        
        Debug.Log(x + "," + z);

        movement = new Vector3(x, 0, z).normalized;
    }

    private void FixedUpdate()
    {
        rigidbody.MovePosition(transform.position + movement * speed * Time.fixedDeltaTime);
    }
}
