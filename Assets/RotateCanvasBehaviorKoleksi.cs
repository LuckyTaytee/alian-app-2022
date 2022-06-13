using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RotateCanvasBehaviorKoleksi : MonoBehaviour
{
    public static RotateCanvasBehaviorKoleksi instance;

    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(ARSessionScript.instance.transform);
        transform.Rotate(0, 180, 0);
    }
}
