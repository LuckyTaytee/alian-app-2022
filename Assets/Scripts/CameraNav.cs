using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class CameraNav : MonoBehaviour
{
    public FixedTouchField TouchField;

    void Update() 
    {
        var fps = GetComponent<RigidbodyFirstPersonController>();

        fps.mouseLook.LookAxis = TouchField.TouchDist;
    }
}
