using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AirTankUI : MonoBehaviour
{
    private const float MAX_OXY = 100f;
    public float oxy = MAX_OXY;
    private Image oxybar;

    public float decreaseAmount = 1f;

    private float lastDecreaseTime;


    void Start()
    {
        oxybar = GetComponent<Image>();
        lastDecreaseTime = Time.time; 
    }

    void Update()
    {
        oxybar.fillAmount = oxy / MAX_OXY;

        if (Time.time - lastDecreaseTime >= 0.5f)
        {
            oxy = oxy - decreaseAmount;
            lastDecreaseTime = Time.time; // Update the last decrease time
        }
    }
}
