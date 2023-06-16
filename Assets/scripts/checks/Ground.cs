using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    private bool onGround;
    private float friction;

    public GameObject oxTank;
    public Collision2D lastCollided;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        EvaluateCollision(collision);
        //RetrieveFriction(collision);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        EvaluateCollision(collision);
        //RetrieveFriction(collision);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (lastCollided == collision)
        {
            switch (collision.gameObject.tag)
            {
                case "Spike":
                    // lower o2 speed
                    oxTank.GetComponent<AirTankUI>().decreaseAmount = 1;
                    break;
            }
            lastCollided = null;
        }
        onGround = false;
        friction = 0;
    }

    private void EvaluateCollision(Collision2D collision)
    {
        lastCollided = collision;
        for (int i=0; i < collision.contactCount; i++)
        {
            Vector2 normal = collision.GetContact(i).normal;
            onGround = normal.y >= 0.9f;
        }

        switch (collision.gameObject.tag)
        {
            case "clam":
                // trigger eating in clam
                break;
            case "Spike":
                // engage o2 speed
                oxTank.GetComponent<AirTankUI>().decreaseAmount = 5;
                break;
            case "George":
                // trigger explosion
                collision.gameObject.GetComponent<GeorgeExplosion>().Explode();
                break;
        }
    }

    //private void RetrieveFriction(Collision2D collision)
    //{
    //    PhysicsMaterial2D material = collision.rigidbody.sharedMaterial;

    //    friction = 0;

    //    if (material != null)
    //    {
    //        friction = material.friction;
    //    }
    //}

    public bool GetOnGround()
    {
        return onGround;
    }

    public float getFriction()
    {
        return friction;
    }
}
