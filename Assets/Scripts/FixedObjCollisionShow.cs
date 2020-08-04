using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FixedObjCollisionShow : MonoBehaviour
{
    private GameObject crash_recorder;
    // Start is called before the first frame update
    void Start()
    {
        crash_recorder = GameObject.Find("crashSoundPlayer");
    }

    // Update is called once per frame
    void Update()
    {
        string str = "";
        foreach(float f in crash_recorder.GetComponent<crashSoundPlayer>().crashes)
        {
            str += f;
            str += "\n";
        }
        GetComponent<Text>().text = "Collisions with fixed objects (speed difference):\n" + str;
    }
}
