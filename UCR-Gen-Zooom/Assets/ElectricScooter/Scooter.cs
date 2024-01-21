using UnityEngine;

public class Scooter : MonoBehaviour
{
    [SerializeField] float motorTorque, brakeTorque, maxSteeringAngle, maxSpeed, motorcycleRotation;

    [SerializeField] WheelCollider frontWheelCollider, backWheelCollider;

    Rigidbody rb;
 
    public static bool isAccelerating, isBraking, isTurningLeft, isTurningRight, isDoingStop;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (isAccelerating)
        {
            backWheelCollider.motorTorque = Mathf.Clamp(motorTorque, -maxSpeed, maxSpeed);
        }
        else
        {
            backWheelCollider.motorTorque = 0;
        }

        if (isBraking)
        {
            frontWheelCollider.brakeTorque = 0;
            backWheelCollider.brakeTorque = 0;
        }

        float steeringAngle = 0;

        if (isTurningLeft)
        {
            steeringAngle = -maxSteeringAngle;
        }
        else if (isTurningRight) {
            steeringAngle = maxSteeringAngle;
        }
        frontWheelCollider.steerAngle = steeringAngle;
        if (isDoingStop)
        {
            motorcycleRotation += .0001f;
            transform.Rotate(motorcycleRotation, 0, 0);
        }
        else
        {
            transform.rotation = Quaternion.identity;
        }
    }
}
