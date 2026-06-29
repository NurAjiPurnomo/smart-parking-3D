using UnityEngine;

public class FollowCarCamera : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0f, 1.0f, -3.8f);
    public float smoothSpeed = 8f;

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.TransformPoint(offset);
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        Vector3 lookPoint = target.position + target.forward * 4f + Vector3.up * 0.8f;
        transform.LookAt(lookPoint);
    }
}