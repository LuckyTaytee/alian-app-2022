using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joystick : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;

    private bool touchStart = false;
    private Vector3 pointA;
    private Vector3 pointB;

    public Transform circle;
    public Transform outerCircle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            /*if (Physics.Raycast(ray, out RaycastHit raycastHit))
            {
                Debug.Log("if passed");
                circle.transform.position = raycastHit.point;
            }*/


            pointA = ray.origin;

            circle.transform.position = ray.origin;
            outerCircle.transform.position = ray.origin;

            circle.GetComponent<SpriteRenderer>().enabled = true;
            outerCircle.GetComponent<SpriteRenderer>().enabled = true;
            
        }
        
        if(Input.GetMouseButton(0))
        {
            touchStart = true;
            pointB = mainCamera.ScreenPointToRay(Input.mousePosition).origin;
        }
        else
        {
            touchStart = false;
        }
    }

    private void FixedUpdate()
    {
        if(touchStart){
            Vector2 offset = pointB - pointA;
            Vector2 direction = Vector2.ClampMagnitude(offset, 1.0f);

            circle.transform.position = new Vector3(pointA.x + direction.x, pointA.y + direction.y, -1.0f) * -1;
        }
        else
        {
            circle.GetComponent<SpriteRenderer>().enabled = false;
            outerCircle.GetComponent<SpriteRenderer>().enabled = false;
        }

	}
}
