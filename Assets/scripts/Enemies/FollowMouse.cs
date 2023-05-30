using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    public Vector3 Motion;
    public float SpeedModif;

    void Update()
    {
        Motion = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        if (Motion != Vector3.zero)
        {
            transform.position += Motion * SpeedModif;
        }
    }
}
