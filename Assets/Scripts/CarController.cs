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
    // INPUT MOBILE
    // =========================
    private void GetInput()
    {
        horizontalInput = MobileInput.steer;
        verticalInput = MobileInput.gas;

        isBraking = MobileInput.brake > 0;
    }


    // =========================
    // MOTOR
    // =========================
    private void HandleMotor()
    {
        // RWD
        rearLeftWheelCollider.motorTorque = verticalInput * motorForce;
        rearRightWheelCollider.motorTorque = verticalInput * motorForce;


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
        UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform, false);
        UpdateSingleWheel(rearLeftWheelCollider, rearLeftWheelTransform, false);

        UpdateSingleWheel(frontRightWheelCollider, frontRightWheelTransform, true);
        UpdateSingleWheel(rearRightWheelCollider, rearRightWheelTransform, true);
    }


    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform, bool isRightSide)
    {
        Vector3 pos;
        Quaternion rot;

        wheelCollider.GetWorldPose(out pos, out rot);

        wheelTransform.position = pos;

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