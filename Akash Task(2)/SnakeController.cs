using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    public List<AxleInfo> axleInfos;
    public float maxMotorTorque;
    public float maxSteeringAngle;

    public static MyCarController cc;

    public float carMaxSpeed = 100;
    public float carCurrentSpeed = 0;

    Rigidbody rb;

    public GameObject SteeringWheel;
    
    // Start is called before the first frame update
    void Start()
    {
        cc = this;
        rb = GetComponent<Rigidbody>();
    }

    public void ApplyLocalPositionToVisuals(WheelCollider collider)
    {
        if(collider.transform.childCount == 0)
        return;
    }
    Transform visualWheel = collider.transform.GetChild(0);
    Vector3 position;
    Quaternion rotation;
    collider.GetWorldPose(out position, out rotation);

    visualWheel.transform.position = position;
    visualWheel.transform.rotation = rotation;

    public void FixedUpdate()
    {
        float motor = maxMotorTorque * Input.GetAxis("Vertical");
        //float steering = maxSteeringAngle * Input.GetAxis("Horizontal");
        float steering = maxSteeringAngle * SteeringWheel.GetComponent<SteeringWheel>().GetClampedValue;

        foreach(AxleInfo axleInfo in axleInfos)
        {
            if(axleInfo.steering)
            {
                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.rightWheel.SteerAngle = steering;
            }
            if(axleInfo.motor)
            {
                axleInfo.leftWheel.motorTorque = motor;
                axleInfo.rightWheel.motorTorque = motor;

                carCurrentSpeed = (rb.velocity.magnitude * 3.6f) / carMaxSpeed;
            }

            ApplyLocalPositionToVisuals(axleInfo.leftWheel);
            ApplyLocalPositionToVisuals(axleInfo.rightWheel);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
