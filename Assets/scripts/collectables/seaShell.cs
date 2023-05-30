using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seaShell : MonoBehaviour
{
    public int seaShellCount = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("seaShell"))
        {
            Destroy(collision.gameObject);
            seaShellCount++;
            Debug.Log(seaShellCount);
        }
    }
}
//gesi wii need too cuuk mempf