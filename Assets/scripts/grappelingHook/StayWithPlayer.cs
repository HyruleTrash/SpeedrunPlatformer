using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayWithPlayer : MonoBehaviour
{
    public GameObject player;

    // Update is called once per frame
    private void LateUpdate()
    {
        if (player != null)
        {
            transform.position = player.transform.position;
        }
    }
}
