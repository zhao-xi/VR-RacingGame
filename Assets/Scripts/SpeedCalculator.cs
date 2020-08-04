using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedCalculator : MonoBehaviour
{
    private float speed;
    private Vector3 lastPosition;
    private GameObject car;

    // Start is called before the first frame update
    void Start()
    {
        car = GameObject.Find("car_root");
        speed = 0f;
        GetComponent<Text>().text = (int) speed + " km/h";
        InvokeRepeating("CalculateSpeed", 0f, 0.3f);

    }

    void CalculateSpeed()
    {

        //speed = (int) (((transform.position - lastPosition).magnitude) / Time.deltaTime);
        speed = (float) (car.GetComponent<Rigidbody>().velocity.magnitude * 3.6);
        GetComponent<Text>().text = (int) speed + " km/h";
    }
}
