using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    private bool onGround;
    private float friction;

    public Vector2 hitForce = new Vector2(-600, -500);

    [Header("Invisability frames")]
    public bool justHit = false;
    public float maxInvisTime = 5;
    float currentInvisTime = 0;
    public float amountOfFramesInFlashColor = 20;
    float currentColorFrameCount = 0;

    public GameObject oxTank;

    private void Update()
    {
        if (justHit)
        {
            currentInvisTime -= Time.deltaTime;
            if (currentInvisTime <= 0)
            {
                justHit = false;
                gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            }

            currentColorFrameCount += Time.deltaTime;
            if (currentColorFrameCount > amountOfFramesInFlashColor)
            {
                if (gameObject.GetComponent<SpriteRenderer>().color == Color.white)
                {
                    gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                }
                else
                {
                    gameObject.GetComponent<SpriteRenderer>().color = Color.white;
                }
                currentColorFrameCount = 0;
            }
        }
    }

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
        onGround = false;
        friction = 0;
    }

    private void EvaluateCollision(Collision2D collision)
    {
        for (int i=0; i < collision.contactCount; i++)
        {
            Vector2 normal = collision.GetContact(i).normal;
            onGround = normal.y >= 0.9f;
        }

        switch (collision.gameObject.tag)
        {
            case "Clam":
                // trigger eating in clam
                gameObject.SetActive(false);
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                collision.transform.parent.gameObject.GetComponent<Clam>().Eating = true;
                break;
            case "Spike":
                // engage o2 speed
                Vector2 forceDirection = (collision.GetContact(0).point - new Vector2(transform.position.x, transform.position.y)).normalized;
                if (!justHit)
                {
                    justHit = true;
                    currentInvisTime = maxInvisTime;
                    oxTank.GetComponent<AirTankUI>().oxy -= 10;
                }
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(forceDirection.x * hitForce.x, forceDirection.y * hitForce.y));
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
