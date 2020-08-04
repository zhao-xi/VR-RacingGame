using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowRaceTimeOnCamera : MonoBehaviour
{
    private GameObject time_recorder;
    // Start is called before the first frame update
    void Start()
    {
        time_recorder = GameObject.Find("Time Recorder");
    }

    // Update is called once per frame
    void Update()
    {
        float time = time_recorder.GetComponent<TimeRecorder>().seconds;
        GetComponent<Text>().text = "Time(s): " + Mathf.Round(time * 100.0f) * 0.01f;
    }
}
