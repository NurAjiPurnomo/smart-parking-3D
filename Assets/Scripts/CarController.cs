using UnityEngine;

public class mobil : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    private float currentSteerAngle;
    private float currentBrakeForce;
    private bool isBraking;

    // =========================
    // SETTINGS
    // =========================
    [Header("Car Settings")]
    [SerializeField] private float motorForce = 1500f;
    [SerializeField] private float brakeForce = 3000f;
    [SerializeField] private float maxSteerAngle = 30f;

    // =========================
    // WHEEL COLLIDERS
    // =========================
    [Header("Wheel Colliders")]
    [SerializeField] private WheelCollider frontLeftWheelCollider;
    [SerializeField] private WheelCollider frontRightWheelCollider;
    [SerializeField] private WheelCollider rearLeftWheelCollider;
    [SerializeField] private WheelCollider rearRightWheelCollider;

    // =========================
    // WHEEL VISUALS
    // =========================
    [Header("Wheel Transforms")]
    [SerializeField] private Transform frontLeftWheelTransform;
    [SerializeField] private Transform frontRightWheelTransform;
    [SerializeField] private Transform rearLeftWheelTransform;
    [SerializeField] private Transform rearRightWheelTransform;

    private void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
    }

    // =========================
    // INPUT
    // =========================
    private void GetInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        isBraking = Input.GetKey(KeyCode.Space);
    }

    // =========================
    // MOTOR
    // =========================
    private void HandleMotor()
    {
        // RWD (penggerak belakang)
        rearLeftWheelCollider.motorTorque = verticalInput * motorForce;
        rearRightWheelCollider.motorTorque = verticalInput * motorForce;

        // Brake
        currentBrakeForce = isBraking ? brakeForce : 0f;

        ApplyBraking();
    }

    // =========================
    // BRAKING
    // =========================
    private void ApplyBraking()
    {
        frontLeftWheelCollider.brakeTorque = currentBrakeForce;
        frontRightWheelCollider.brakeTorque = currentBrakeForce;

        rearLeftWheelCollider.brakeTorque = currentBrakeForce;
        rearRightWheelCollider.brakeTorque = currentBrakeForce;
    }

    // =========================
    // STEERING
    // =========================
    private void HandleSteering()
    {
        currentSteerAngle = maxSteerAngle * horizontalInput;

        frontLeftWheelCollider.steerAngle = currentSteerAngle;
        frontRightWheelCollider.steerAngle = currentSteerAngle;
    }

    // =========================
    // UPDATE WHEELS
    // =========================
    private void UpdateWheels()
    {
        // kiri = normal
        UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform, false);
        UpdateSingleWheel(rearLeftWheelCollider, rearLeftWheelTransform, false);

        // kanan = dibalik
        UpdateSingleWheel(frontRightWheelCollider, frontRightWheelTransform, true);
        UpdateSingleWheel(rearRightWheelCollider, rearRightWheelTransform, true);
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform, bool isRightSide)
    {
        Vector3 pos;
        Quaternion rot;

        // Ambil posisi & rotasi WheelCollider
        wheelCollider.GetWorldPose(out pos, out rot);

        // Update posisi roda
        wheelTransform.position = pos;

        // Fix roda kanan
        if (isRightSide)
        {
            wheelTransform.rotation = rot;
        }
        else
        {
            wheelTransform.rotation = rot * Quaternion.Euler(0f, 180f, 0f);
        }
    }
}