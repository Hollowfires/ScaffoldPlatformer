using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(newController2D))]
public class testPlayer : MonoBehaviour
{

    public float jumpHeight = 4;
    public float timeToJumpApex = .4f;
    public float moveSpeed = 6;

    float gravity;
    float jumpVelocity;
    float maxgravity;

    public bool grounded; //remove public
    public bool jumping; //remove public

    public Vector3 velocity; //remove public

    newController2D controller;

    void Start()
    {
        controller = GetComponent<newController2D>();

        gravity = -(2 * jumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        jumpVelocity = Mathf.Abs(gravity * timeToJumpApex);
        //maxgravity = gravity * 3;
        print("Gravity " + gravity + " Jump Velocity: " + jumpVelocity);

    }

    void Update() //change back to Update
    {
        if (controller.collisions.below == true)
        {
            grounded = true;

            if (jumping == true)
            {
                jumping = false;
            }
        }

        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));  //stores player input

        if (Input.GetKeyDown(KeyCode.Space) && grounded)//controller.collisions.below)
        {
            grounded = false;
            jumping = true;
            velocity.y = jumpVelocity;
        }
        velocity.x = input.x * moveSpeed;
        if (velocity.y <= gravity / 8 & grounded == true)
        {
            velocity.y = 0;
        }
        else if (grounded == false)
        {
            velocity.y += gravity * Time.deltaTime; // main gravity string
        }
        //velocity.y = -9.8f;
        controller.Move(velocity * Time.deltaTime);

        //movement feels fluid, need to polish "grounded" aspect or add a input buffer to jumping (press jump before hitting floor, let the player jump immediately after hitting)

        //if not affected by gravity, add to velocity.y
        //if (controller.collisions.above || controller.collisions.below) //this part is what's causing "sinking"
        //{
        //velocity.y = 0;
        //}

        if (controller.collisions.below == false)
        {
            if (jumping != true && grounded == true)
            {
                velocity.y = velocity.y;//-gravity/32;
            }

            grounded = false;
        }

    }

}

