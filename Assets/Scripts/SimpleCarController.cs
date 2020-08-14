using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AxleInfo
{
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor;
    public bool steering;
}

public class SimpleCarController : MonoBehaviour
{
    public List<AxleInfo> axleInfos;
    public float maxMotorTorque;
    public float maxSteeringAngle;
    private GameObject wheel_fl;
    private GameObject wheel_fr;

    private GameObject steering_wheel_rotator;
    public void Start()
    {
        steering_wheel_rotator = GameObject.Find("rotator");
        wheel_fl = GameObject.Find("wheel_fl");
        wheel_fr = GameObject.Find("wheel_fr");
    }

    // finds the corresponding visual wheel
    // correctly applies the transform
    public void ApplyLocalPositionToVisuals(WheelCollider collider)
    {
        if (collider.transform.childCount == 0)
        {
            return;
        }

        Transform visualWheel = collider.transform.GetChild(0);

        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);

        visualWheel.transform.position = position;
        visualWheel.transform.rotation = rotation;
    }

    public void FixedUpdate()
    {
        float motor = maxMotorTorque * Input.GetAxis("Vertical");
        Debug.Log("Vertical(Accelerate) : " + Input.GetAxis("Vertical"));
        float steering = maxSteeringAngle * (steering_wheel_rotator.GetComponent<Steering>().sum_angle) / 300f;

        foreach (AxleInfo axleInfo in axleInfos)
        {
            if (axleInfo.steering)
            {
                axleInfo.leftWheel.steerAngle = steering;
                wheel_fl.transform.localEulerAngles = new Vector3(wheel_fl.transform.localEulerAngles.x, -steering, wheel_fl.transform.localEulerAngles.z);
                axleInfo.rightWheel.steerAngle = steering;
                wheel_fr.transform.localEulerAngles = new Vector3(wheel_fr.transform.localEulerAngles.x, -steering, wheel_fr.transform.localEulerAngles.z);
            }
            if (axleInfo.motor)
            {
                axleInfo.leftWheel.motorTorque = motor;
                axleInfo.rightWheel.motorTorque = motor;
            }
            ApplyLocalPositionToVisuals(axleInfo.leftWheel);
            ApplyLocalPositionToVisuals(axleInfo.rightWheel);
        }
    }
}
