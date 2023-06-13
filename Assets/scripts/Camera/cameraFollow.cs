using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform Target;
    public Vector3 offset;
    [Range(1, 10)]
    public float smoothFactor;

    Vector3 oldposition;

    private void FixedUpdate()
    {
        oldposition = transform.position;
        Follow();
        if (oldposition.x > transform.position.x)
        {
            transform.position = new Vector3(oldposition.x, transform.position.y, transform.position.z);
        }
    }

    void Follow()
    {
        Vector3 targetPosition = Target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPosition, smoothFactor * Time.fixedDeltaTime);
        transform.position = smoothedPosition;
    }
}
