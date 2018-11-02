using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //TODO: Collision Detection


    bool Right;
    bool Left;
    bool Up;
    bool Down;

    //temp velocity to add to player (it's a vector3 for easy addition)
    Vector3 velocity;

    //Acceleration Speed
    public float AccSpeed;
    //Decelleration Speed
    public float DecSpeed;
    //Max Movespeed
    public float MaxMove;
    //Min Movespeed
    public float MinMove;

    private void Update()
    {
        //Set bools equal to input (GetButton is for Input from project settings)
        Right = Input.GetButton("Right");
        Left = Input.GetButton("Left");
        Up = Input.GetButton("Up");
        Down = Input.GetButton("Down");

        //Series of ifs for detecting input and adding to velocity
        //Adds to velocity either the max or the sum(whichever is smaller)
        if (Right)
        {
            velocity.x = Mathf.Min(velocity.x + AccSpeed, MaxMove);
        }
        if (Left)
        {
            velocity.x = Mathf.Max(velocity.x - AccSpeed, -MaxMove);
        }
        if (Up)
        {
            velocity.y = Mathf.Min(velocity.y + AccSpeed, MaxMove);
        }
        if (Down)
        {
            velocity.y = Mathf.Max(velocity.y - AccSpeed, -MaxMove);
        }

       
        if(!Right && !Left)
        {
            if(velocity.x < 0)
            {
                velocity.x += DecSpeed;
            }
            if(velocity.x > 0)
            {
                velocity.x -= DecSpeed;
            }
        }
        if(!Up && !Down)
        {
            if (velocity.y < 0)
            {
                velocity.y += DecSpeed;
            }            
            if (velocity.y > 0)
            {            
                velocity.y -= DecSpeed;
            }
        }

        //if too slow then stop instead of sliding
        if(Mathf.Abs(velocity.x) < MinMove)
        {
            velocity.x = 0;
        }
        if (Mathf.Abs(velocity.y) < MinMove)
        {
            velocity.y = 0;
        }


        transform.position += velocity;
    }
}
