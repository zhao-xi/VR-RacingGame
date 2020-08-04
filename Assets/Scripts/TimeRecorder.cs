using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeRecorder : MonoBehaviour
{
    public float seconds;
    private GameObject car;

    private bool start;
    // Start is called before the first frame update
    void Start()
    {
        seconds = 0.0f;
        car = GameObject.Find("car_root");
        start = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!start)
        {
            if((float)(car.GetComponent<Rigidbody>().velocity.magnitude * 3.6) > 1)
            {
                start = true;
            }
        }
        if (start)
        {
            seconds += Time.deltaTime;
        }
    }
}
