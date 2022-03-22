using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    
    public Transform cam;


    private void Start()
    {
        cam = Transform.FindObjectOfType<Camera>().transform;
    }
    // Update is called once per frame
    void LateUpdate()
    {
        transform.LookAt(transform.position + cam.forward);
    }
}
