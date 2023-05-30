using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUp : MonoBehaviour
{
    public int seaShellCount = 0;
    private bool collecting = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("seaShell") && !collecting)
        {
            collecting = true;
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