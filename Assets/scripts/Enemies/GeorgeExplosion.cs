using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeorgeExplosion : MonoBehaviour
{
    public GameObject boomParticleSystem;
    public GameObject Player;

    bool played = false;
    Death deathLocation;

    private void Start()
    {
        deathLocation = GameObject.Find("FadeToBlack").GetComponent<Death>();
    }

    public void Explode()
    {
        if (!played)
        {
            boomParticleSystem.transform.GetComponent<ParticleSystem>().Play();
            transform.GetComponent<SpriteRenderer>().enabled = false;
            Destroy(transform.GetComponent<HingeJoint2D>());
            Destroy(transform.GetComponent<Rigidbody2D>());
            gameObject.tag = "Untagged";
            played = true;
            deathLocation.TriggerDeath();
        }
    }

    private void Update()
    {
        if (played && boomParticleSystem.transform.GetComponent<ParticleSystem>().isPlaying == false)
        {
            // Transition to death screen
            deathLocation.TriggerDeathFade();
        }
    }
}
