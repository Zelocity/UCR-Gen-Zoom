using UnityEngine;

public class scooterMovement : MonoBehaviour
{
    [SerializeField] float motorTorque, brakeTorque, maxSteeringAngle, maxSpeed, motorcycleRotation;

    [SerializeField] WheelCollider frontWheelCollider, backWheelCollider;

    Rigidbody rb;

    float steeringAngle = 0;
    public static bool isAccelerating, isBraking, isTurningLeft, isTurningRight, isDoingStop;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        if (verticalInput == 0 && horizontalInput ==0 )
        {
            rb.velocity = Vector3.zero;
        }

        //if vertical input is positive (w, up, forward), the scooter accelerates
        if (verticalInput > 0)
        {
            backWheelCollider.motorTorque = Mathf.Clamp(motorTorque, -maxSpeed, maxSpeed);
        } 
        else 
        {
            backWheelCollider.motorTorque = 0;
        }

        //if vertical input is negative (s, down, backwards), the scooter brakes
        if (verticalInput < 0)
        {
            Debug.LogWarning("BRAKE");
            frontWheelCollider.brakeTorque = 0;
            backWheelCollider.brakeTorque = 0;
            
        }

       

        //if horizontal input is negative (left), the scooter goes left
        if (horizontalInput < 0)
        {
            steeringAngle = -maxSteeringAngle;
        }
        //if horizontal input is positive (right), the scooter goes right
        else if (horizontalInput > 0) {
            steeringAngle = maxSteeringAngle;
        } else
        {
            steeringAngle = 0;
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
