using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStates : MonoBehaviour
{
    public Animator Player;
    private Rigidbody2D rb;
    private Ground ground;

    private bool onGround;
    private bool up;

    private float lasty;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ground = GetComponent<Ground>();
    }

    void Update()
    {
        onGround = ground.GetOnGround();
        float currentY = transform.position.y;

        //check y
        if (currentY > lasty)
        {
            up = true;
        }
        else if (currentY < lasty)
        {
            up = false;
        }
        lasty = currentY;

        //change to idle
        if (rb.velocity.magnitude > 0 && onGround)
        {
            Player.ResetTrigger("down");
            Player.ResetTrigger("idle");
            Player.SetTrigger("run");

        }
        //change to run
        else if (rb.velocity.magnitude <= 0 && onGround)
        {
            Player.ResetTrigger("down");
            Player.ResetTrigger("run");
            Player.SetTrigger("idle");
        }
        //change to up
        else if (!onGround && up)
        {
            Player.ResetTrigger("run");
            Player.ResetTrigger("idle");
            Player.SetTrigger("up");
        }
        //change to down
        else if (!onGround && !up) 
        {
            Player.ResetTrigger("run");
            Player.ResetTrigger("idle");
            Player.ResetTrigger("up");
            Player.SetTrigger("down");
        }
    }
}
