using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Target Settings")]
    public Transform target;
    public Vector3 offset = new Vector3(0, 5, -8);

    [Header("Smooth Settings")]
    [Range(1f, 15f)]
    public float smoothSpeed = 5f;

    void LateUpdate()
    {
        if (target == null) return;

        // 1. Hitung posisi ideal kamera berdasarkan posisi dan rotasi target
        Vector3 desiredPosition = target.position + target.TransformDirection(offset);

        // 2. Menggunakan Mathf.Exp untuk pergerakan Lerp yang jauh lebih smooth 
        // dan tidak terpengaruh oleh naik-turunnya FPS (Frame Rate Independent)
        float t = 1f - Mathf.Exp(-smoothSpeed * Time.deltaTime);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, t);

        // 3. Terapkan posisi baru
        transform.position = smoothedPosition;

        // 4. Agar rotasi kamera saat menghadap player juga smooth (tidak kaku),
        // kita bisa mengganti transform.LookAt(target) dengan Quaternion.Slerp
        Quaternion targetRotation = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, t);
    }
}