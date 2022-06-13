using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifecycle4Behavior : MonoBehaviour
{
    public static Lifecycle4Behavior instance;

    // Start is called before the first frame update
    void Start()
    {
        RotateCanvasBehavior.instance.minigameObject = gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
