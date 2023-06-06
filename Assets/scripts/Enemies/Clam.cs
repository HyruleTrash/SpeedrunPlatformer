using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clam : MonoBehaviour
{
    public GameObject player;
    public GameObject Indicator;
    public Vector2 EatingOffset;
    public Vector3 MaxJump;
    public float DetectionDistence = 0.15f;
    public float JumpSpeed = 2f;
    public float DesendSpeed = 1.5f;
    public float EatingSpeed = 1.5f;
    public Sprite MouthOpen;
    public Sprite MouthClose;

    public AnimationCurve JumpCurve;

    Vector2 StartPosition;
    bool jumping;
    public bool Eating;

    private void Start()
    {
#if UNITY_EDITOR
        Indicator.SetActive(true);
#endif
#if !UNITY_EDITOR
        Indicator.SetActive(false);
#endif

        StartPosition = transform.position;
    }

    void Update()
    {
#if UNITY_EDITOR
        Indicator.transform.position = new Vector3((MaxJump.x + StartPosition.x), (MaxJump.y + StartPosition.y) / 2);
        Indicator.transform.localScale = new Vector2(DetectionDistence, (MaxJump.y + StartPosition.y));
#endif

        if (Mathf.Abs(player.transform.position.x - transform.position.x) < DetectionDistence / 2 && Vector3.Distance(transform.position, StartPosition) <= 0.2 && !Eating)
        {
            jumping = true;
        }

        if (jumping == true)
        {
            GameObject.Find("Clam/Visual").GetComponent<SpriteRenderer>().sprite = MouthOpen;
            float PercentageAlongJump = 1 - Vector3.Distance(transform.position, MaxJump) / Vector3.Distance(MaxJump, StartPosition);
            transform.position = Vector3.Lerp(transform.position, MaxJump, Time.deltaTime * (JumpSpeed * JumpCurve.Evaluate(PercentageAlongJump)));
            if (Vector3.Distance(transform.position, MaxJump) <= 0.2)
            {
                transform.position = MaxJump;
                jumping = false;
            }
        }
        else
        {
            GameObject.Find("Clam/Visual").GetComponent<SpriteRenderer>().sprite = MouthClose;
            if (Vector3.Distance(transform.position, StartPosition) >= 0.2 && !Eating)
            {
                transform.position = Vector3.Lerp(transform.position, StartPosition, Time.deltaTime * DesendSpeed);
            }
            else if (!Eating)
            {
                transform.position = StartPosition;
            }
            if (Eating)
            {
                if (transform.position.y > StartPosition.y + EatingOffset.y)
                {
                    transform.position -= new Vector3(0, Time.deltaTime * EatingSpeed, 0);
                }
                else
                {
                    transform.position = EatingOffset;
                    Eating = false;
                }
            }
        }
    }
}