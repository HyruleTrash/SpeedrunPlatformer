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
    public float oxygen;
    public AirTankUI airTankUI;

    public AudioSource picker;
    private void Start()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("seaShell") && !collecting)
        {
            collecting = true;
            picker.Play();
            Instantiate(particle, collision.gameObject.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            seaShellCount++;
            ShellText.text = System.Convert.ToString(seaShellCount);
        }
        if (collision.gameObject.CompareTag("AirTank") && !collecting)
        {
            collecting = true;
            picker.Play();
            Instantiate(particle, collision.gameObject.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            airTankUI.gainOxy();
        }
    }

    void Update()
    {
        collecting = false;   
        
    }
}

//gesi wii need too cuuk mempf