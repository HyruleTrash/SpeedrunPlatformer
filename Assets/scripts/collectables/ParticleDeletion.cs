using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDeletion : MonoBehaviour
{
    void Update()
    {
        if (!gameObject.GetComponent<ParticleSystem>().isPlaying)
        {
            Destroy(gameObject);
        }
    }
}
