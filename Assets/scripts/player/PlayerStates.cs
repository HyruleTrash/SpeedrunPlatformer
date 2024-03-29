using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStates : MonoBehaviour
{
    public Animator Player;
    private Rigidbody2D rb;
    private Ground ground;
    private walll_Jump walljump;

    private bool onGround;
    private bool up;

    private float lasty;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ground = GetComponent<Ground>();
        walljump = GetComponent<walll_Jump>();
    }

    void Update()
    {
        onGround = ground.GetOnGround();
        float currentY = transform.position.y;
        bool issliding = walljump.isWallSliding;

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

        //change to run
        if (rb.velocity.magnitude > 0 && onGround)
        {
            Player.ResetTrigger("wall");
            Player.ResetTrigger("down");
            Player.ResetTrigger("idle");
            Player.SetTrigger("run");

        }
        //change to idle
        else if (rb.velocity.magnitude <= 0 && onGround)
        {
            Player.ResetTrigger("wall");
            Player.ResetTrigger("down");
            Player.ResetTrigger("run");
            Player.SetTrigger("idle");
        }
        //change to up
        else if (!onGround && up)
        {
            Player.ResetTrigger("wall");
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
        if (walljump != null && issliding == true)
        {
            Player.SetTrigger("wall");
            Player.ResetTrigger("run");
            Player.ResetTrigger("idle");
            Player.ResetTrigger("up");
            Player.ResetTrigger("down");
        }
    }
}
