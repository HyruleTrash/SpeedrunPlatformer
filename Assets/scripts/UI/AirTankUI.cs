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

    public float increaseOxy;

    Death deathLocation;

    void Start()
    {
        deathLocation = GameObject.Find("FadeToBlack").GetComponent<Death>();
        oxybar = GetComponent<Image>();
        lastDecreaseTime = Time.time; 
    }

    void Update()
    {
        oxybar.fillAmount = oxy / MAX_OXY;

        if (Time.time - lastDecreaseTime >= 0.5f)
        {
            oxy = oxy - decreaseAmount;
            lastDecreaseTime = Time.time;
        }
        //death
        if (oxy <= 0)
        {
            //do the death
            deathLocation.TriggerDeath();
            deathLocation.TriggerDeathFade();
        }
    }

    public void gainOxy()
    {
        oxy = oxy + increaseOxy;
        if (oxy > 100f)
        {
            oxy = 100;
        }
    }
}
