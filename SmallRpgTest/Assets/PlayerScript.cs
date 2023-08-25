using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AnimationState
{
    idle=0,
    up=1, 
    down=2, 
    left=3, 
    right=4,
}

public class PlayerScript : MonoBehaviour
{
    public Transform sprite;
    public Sprite spr;
    public Rigidbody2D rb;

    public float speed;

    Vector2 leftinput;

    AnimationState animationState = AnimationState.idle;

    private void Update()
    {
        animationHandler();
        Debug.Log(animationState);
    }

    private void FixedUpdate()
    {
        leftinput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        rb.velocity = leftinput * speed;
    }

    void animationHandler()
    {
        if (leftinput.x == 0 && leftinput.y == 0)
        {
            animationState = AnimationState.idle;
        } 
        if (leftinput.x > 0 && Betweenxy(-0.5f, -0.5f, leftinput.y))
        {
            animationState = AnimationState.right;
        }
        if (leftinput.x < 0 && Betweenxy(-0.5f, -0.5f, leftinput.y))
        {
            animationState = AnimationState.left;
        }
        if (Betweenxy(-0.5f, -0.5f, leftinput.x) && leftinput.y < 0)
        {
            animationState = AnimationState.down;
        }
        if (Betweenxy(-0.5f, -0.5f, leftinput.x) && leftinput.y > 0)
        {
            animationState = AnimationState.up;
        }
    }

    bool Betweenxy(float x,float y, float input)
    {
        if (input < x && input > y)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
