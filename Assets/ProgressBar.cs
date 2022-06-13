using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBar : MonoBehaviour
{
    public static ProgressBar instance;
    public GameObject minigameObject;
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
        if (minigameObject != null)
        {
            transform.GetComponent<Canvas>().enabled = true;
            transform.position = new Vector3(minigameObject.transform.position.x, minigameObject.transform.position.y + 0.1f, minigameObject.transform.position.z);
        }
        else
        {
            transform.GetComponent<Canvas>().enabled = false;
        }
        transform.LookAt(ARSessionScriptPembelajaranAR.instance.transform);
        transform.Rotate(0, 180, 0);
    }
}
