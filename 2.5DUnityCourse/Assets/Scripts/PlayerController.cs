using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int speed;
    [SerializeField] private Animator anim;
    [SerializeField] private SpriteRenderer playerSprite;

    private PlayerControls playerControls;
    private Rigidbody rigidbody;
    private Vector3 movement;

    private const string IS_WALK_PARAM = "IsWalk";

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

        movement = new Vector3(x, 0, z).normalized;

        anim.SetBool(IS_WALK_PARAM, movement!=Vector3.zero);

        if(x!=0 && x<0){
            playerSprite.flipX = true;
        }

        if(x!=0 && x>0) {
            playerSprite.flipX = false;
        }
    }

    private void FixedUpdate()
    {
        rigidbody.MovePosition(transform.position + movement * speed * Time.fixedDeltaTime);
    }
}
