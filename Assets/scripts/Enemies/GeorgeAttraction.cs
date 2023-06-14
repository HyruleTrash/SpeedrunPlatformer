using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeorgeAttraction : MonoBehaviour
{
    public GameObject Player;
    public float attractionStrength = 0.1f;

    private void Update()
    {
        if (transform.GetComponent<Rigidbody2D>())
        {
            Vector3 normalizedDirection = (Player.transform.position - transform.position).normalized;
            transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(normalizedDirection.x * attractionStrength, normalizedDirection.y * attractionStrength));
        }
    }
}
