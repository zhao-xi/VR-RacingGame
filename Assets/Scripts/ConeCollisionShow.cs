using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConeCollisionShow : MonoBehaviour
{
    private GameObject collision_recorder;
    // Start is called before the first frame update
    void Start()
    {
        collision_recorder = GameObject.Find("Collision Recorder");
    }

    // Update is called once per frame
    void Update()
    {
        int collision = collision_recorder.GetComponent<CollisionRecorder>().collisions_cone;
        GetComponent<Text>().text = "Cone_collisions: " + collision;
    }
}
