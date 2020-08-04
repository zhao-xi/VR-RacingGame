using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crashSoundPlayer : MonoBehaviour
{

    float physics_speed = 0;
    float prev_speed = 0;
    GameObject car;
    public List<float> crashes = new List<float>();

    private float lastCollision; // avoid double collision

    private void Start()
    {
        car = GameObject.Find("car_root");
        lastCollision = Time.time;
    }


    void FixedUpdate()
    {
        physics_speed = car.GetComponent<Rigidbody>().velocity.magnitude;
        if (Mathf.Abs(physics_speed - prev_speed) > 1f)
        {
            if (Time.time - lastCollision > 1f)
            {
                GetComponent<AudioSource>().volume = Mathf.Min(Mathf.Abs(physics_speed - prev_speed) / 10f, 1f) * 0.1f;
                GetComponent<AudioSource>().Play();
                crashes.Add((float)(physics_speed - prev_speed) * 3.6f);
                lastCollision = Time.time;
            }
        }
        prev_speed = physics_speed;
    }
}
