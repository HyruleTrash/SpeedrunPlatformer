using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUp : MonoBehaviour
{
    public int seaShellCount = 0;
    private bool collecting = false;
    public ParticleSystem particle;

    private void Awake()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("seaShell") && !collecting)
        {
            collecting = true;
            Instantiate(particle, collision.gameObject.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            seaShellCount++;
            Debug.Log(seaShellCount);
        }
    }

    void Update()
    {
        collecting = false;    
    }
}

//gesi wii need too cuuk mempf