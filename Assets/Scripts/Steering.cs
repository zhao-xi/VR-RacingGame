using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steering : MonoBehaviour
{
    private float rotationSpeed = 400f;

    public float sum_angle = 0f;
    private void Update()
    {
        if (Input.GetAxis("Horizontal") == 1 && sum_angle < 300)
        {
            float diff = transform.localEulerAngles.y;
            transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
            if(transform.localEulerAngles.y - diff < -180)
            {
                sum_angle += 360 - diff + transform.localEulerAngles.y;
            }
            else
            {
                sum_angle += transform.localEulerAngles.y - diff;
            }
        }
        if (Input.GetAxis("Horizontal") == -1 && sum_angle > -300)
        {
            float diff = transform.localEulerAngles.y;
            transform.Rotate(0f, -rotationSpeed * Time.deltaTime, 0f);
            if (transform.localEulerAngles.y - diff > 180)
            {
                sum_angle += transform.localEulerAngles.y - 360 - diff;
            }
            else
            {
                sum_angle += transform.localEulerAngles.y - diff;
            }
        }
    }
}
