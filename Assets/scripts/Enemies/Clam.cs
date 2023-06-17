using System.ComponentModel;
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

    [Header("Health parameters")]
    public int maxHealth = 5;
    public int currentHealth = 0;

    [System.Serializable]
    public class SpriteState
    {
        public string name;
        public Sprite sprite;
    }
    public List<SpriteState> Sprites = new List<SpriteState>();

    public AnimationCurve JumpCurve;

    Vector2 StartPosition;
    bool jumping;
    public bool Eating;
    Death deathLocation;

    bool pressingSpace = false;

    public int GetSpriteStateWithName(string name)
    {
        // loop trough list, return id if name is the same
        for (int i = 0; i < Sprites.Count; i++)
        {
            if (Sprites[i].name == name)
            {
                return i;
            }
        }
        // return -1 if nothing is found
        return -1;
    }


    private void Start()
    {
        currentHealth = maxHealth;
        deathLocation = GameObject.Find("FadeToBlack").GetComponent<Death>();
        MaxJump += new Vector3(transform.position.x, 0, 0);

#if UNITY_EDITOR
        Indicator.SetActive(true);
        Indicator.transform.parent = transform.parent;
#endif
#if !UNITY_EDITOR
        Indicator.SetActive(false);
#endif

        StartPosition = transform.position;
    }

    void Update()
    {
        // setting Indicator
#if UNITY_EDITOR
        Indicator.transform.position = new Vector3(MaxJump.x, StartPosition.y + (Vector3.Distance(MaxJump, StartPosition) / 2));
        Indicator.transform.localScale = new Vector2(DetectionDistence, Vector3.Distance(MaxJump, StartPosition));
#endif

        // is player and are you not already eating
        if (Mathf.Abs(player.transform.position.x - transform.position.x) < DetectionDistence / 2 && Vector3.Distance(transform.position, StartPosition) <= 0.2 && !Eating)
        {
            jumping = true;
        }

        // if jumping open mouth and get percentatge along curve compared to the end of the jump.
        // then set position
        if (jumping == true)
        {
            GameObject.Find("Clam/Visual").GetComponent<SpriteRenderer>().sprite = Sprites[GetSpriteStateWithName("MouthOpen")].sprite;
            float PercentageAlongJump = 1 - Vector3.Distance(transform.position, MaxJump) / Vector3.Distance(MaxJump, StartPosition);
            transform.position = Vector3.Lerp(transform.position, MaxJump, Time.deltaTime * (JumpSpeed * JumpCurve.Evaluate(PercentageAlongJump)));

            // if at max end the jump
            if (Vector3.Distance(transform.position, MaxJump) <= 0.2)
            {
                transform.position = MaxJump;
                jumping = false;
            }
        }
        else
        {
            // if not jumping
            GameObject.Find("Clam/Visual").GetComponent<SpriteRenderer>().sprite = Sprites[GetSpriteStateWithName("MouthCloseWait")].sprite;
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
                player.transform.position = transform.position;
                GameObject.Find("Clam/Visual").GetComponent<SpriteRenderer>().sprite = Sprites[GetSpriteStateWithName("MouthCloseRetreat")].sprite;
                // check if struggling
                if (Input.GetKeyDown("space") && !pressingSpace)
                {
                    pressingSpace = true;
                }
                else if (Input.GetKeyUp("space") && pressingSpace)
                {
                    pressingSpace = false;
                }

                // go down and if its to far down kill the player
                if (transform.position.y > StartPosition.y + EatingOffset.y)
                {
                    transform.position -= new Vector3(0, Time.deltaTime * EatingSpeed, 0);
                }
                else
                {
                    transform.position = StartPosition + EatingOffset;
                    deathLocation.TriggerDeath();
                    deathLocation.TriggerDeathFade();
                }
            }
        }

    }
    void OnDrawGizmosSelected()
    {
        StartPosition = transform.position;
        // Draw a semitransparent red cube at the transforms position
        Gizmos.color = Color.red;
        Gizmos.DrawCube(StartPosition + EatingOffset, new Vector3(1,1,1));
    }
}
