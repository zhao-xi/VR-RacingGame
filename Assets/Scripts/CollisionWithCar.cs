using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionWithCar : MonoBehaviour
{
    bool alreadyHit;
    private void Start()
    {

        alreadyHit = false;

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Car" && !alreadyHit)
        {

            // +1 collision
            switch (gameObject.tag)
            {
                case "Cone":
                    GameObject.Find("Collision Recorder").GetComponent<CollisionRecorder>().collisions_cone += 1; break;
            }
            

            // play a colliding sound
            GetComponent<AudioSource>().Play();

            // mark it as already hit
            alreadyHit = true;
        }
    }

    private void Update()
    {
        if (alreadyHit)
        {
            // destroy the obstacle after 1 seconds it's been hit
            // if destroy it immediately after hit, AudioSource can't be played
            Destroy(gameObject, 1.0f);
        }
    }
}
