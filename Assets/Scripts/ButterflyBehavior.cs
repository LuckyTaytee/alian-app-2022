using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyBehavior : MonoBehaviour
{
    public static ButterflyBehavior instance;
    public static SpawnButterfly VRCamera;
    public GameObject buttonToActivate;
    public float butterflySpeed;
    public Vector3 lastPosition;
    public Vector3 nextPosition;
    public float butterflyDespawnTime;
    private float startTime;
    private float timeStopped;
    private bool stop = false;
    private GameObject parentCanvas;
        private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        parentCanvas = GameObject.Find("Canvas");
        startTime = Time.time;
        VRCamera = SpawnButterfly.instance;
        lastPosition = transform.position;
        nextPosition = VRCamera.generateSpawnCircle() + VRCamera.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!stop) 
        {
            transform.position = Vector3.MoveTowards(transform.position, nextPosition, butterflySpeed / 1000);
        }
       
            
        if (transform.position == nextPosition) {
         lastPosition = transform.position;
            int random = Random.Range(0, 2);
            if (random == 0)
            {
                timeStopped = Time.time;
                stop = true;
            }
            else 
            {
                nextPosition = VRCamera.generateSpawnCircle()+VRCamera.transform.position;
            }
           
        }

       if (Time.time - timeStopped >= 2)
       {
           
            stop = false;
       }

        if (Time.time - startTime >= butterflyDespawnTime) 
        {
            Destroy(gameObject);
            SpawnButterfly.instance.currentButterfly--;
        
        }
        
        
    }

    public void ActivateButton() 
    {
      

        

    }


}
