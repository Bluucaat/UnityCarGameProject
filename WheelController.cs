using UnityEngine;

public class WheelController : MonoBehaviour

{
    [SerializeField] WheelCollider frontRight;
    [SerializeField] WheelCollider frontLeft;
    [SerializeField] WheelCollider backRight;
    [SerializeField] WheelCollider backLeft;


    [SerializeField] Transform frontRightTransform;
    [SerializeField] Transform frontLeftTransform;
    [SerializeField] Transform backLeftTransform;
    [SerializeField] Transform backRightTransform;


    public float acceleration;
    public float maxTurnAngle;

    private float currentAcceleration;
    private float currentTurnAngle;

    void FixedUpdate()
    {
        currentAcceleration = acceleration * (Input.GetAxis("Vertical"));


        frontRight.motorTorque = currentAcceleration;
        frontLeft.motorTorque = currentAcceleration;




        currentTurnAngle = maxTurnAngle * Input.GetAxis("Horizontal");
        frontLeft.steerAngle = currentTurnAngle;
        frontRight.steerAngle = currentTurnAngle;

        UpdateWheel(frontLeft, frontLeftTransform);
        UpdateWheel(frontRight, frontRightTransform);
        UpdateWheel(backLeft, backLeftTransform);
        UpdateWheel(backRight, backRightTransform);
    }

    void UpdateWheel(WheelCollider col, Transform trans)
    {
        Vector3 positions;
        Quaternion rotation;
        col.GetWorldPose(out positions, out rotation);


        trans.position = positions;
        trans.rotation = rotation;
    }
}
