using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class pickUp : MonoBehaviour
{
    public int seaShellCount = 0;
    private bool collecting = false;
    public ParticleSystem particle;
    public TextMeshProUGUI ShellText;

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
            ShellText.text = System.Convert.ToString(seaShellCount);
            Debug.Log(seaShellCount);
        }
    }

    void Update()
    {
        collecting = false;    
    }
}

//gesi wii need too cuuk mempf