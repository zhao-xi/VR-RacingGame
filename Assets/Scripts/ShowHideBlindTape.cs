using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHideBlindTape : MonoBehaviour
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
        if (Input.GetKeyDown(KeyCode.B))
        {
            show = !show;
        }
        GetComponent<MeshRenderer>().enabled = show;
    }
}
