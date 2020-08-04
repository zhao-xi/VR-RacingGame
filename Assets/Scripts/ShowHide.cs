using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHide : MonoBehaviour
{
    private bool show;
    // Start is called before the first frame update
    void Start()
    {
        show = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.H))
        {
            show = !show;
        }
        GetComponent<Canvas>().enabled = show;
    }
}
