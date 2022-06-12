using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCanvasBehavior : MonoBehaviour
{
    public GameObject ARCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(ARCamera.transform);
        transform.Rotate(0, 180, 0);
    }
}
