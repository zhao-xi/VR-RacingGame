using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    float speed = 0;
    float highest_speed = 20;
    float rate = 0;
    
    // Update is called once per frame
    void Update()
    {
        speed = GetComponent<Rigidbody>().velocity.magnitude;
        rate = speed / highest_speed;
        GetComponent<AudioSource>().pitch = Mathf.Min(rate, 1.5f);
    }

}
