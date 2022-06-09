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
    public Quaternion lastRotation;
    public Quaternion nextRotation;
    public float butterflyDespawnTime;
    private float startTime;
    private float timeStopped;
    private bool stop = false;
        private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        VRCamera = SpawnButterfly.instance;
        lastPosition = transform.position;
        lastRotation = transform.rotation;
        if (VRCamera != null)
        {
            nextPosition = VRCamera.generateSpawnCircle() + VRCamera.transform.position;
            nextRotation = Quaternion.LookRotation(nextPosition - lastPosition).normalized;
            nextRotation *= Quaternion.Euler(30, 0, 0);
        } //setting awal rotasi}
        Animator animator = gameObject.GetComponent<Animator>();
        animator.speed = (1 + (butterflySpeed - 5) / 4);
      
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, nextRotation, (float)(Time.deltaTime * (butterflySpeed / 5)));

        if (!stop & VRCamera!= null) 
        {
            transform.position = Vector3.MoveTowards(transform.position, nextPosition, butterflySpeed / 1000); //menggerakan kupu ke posisi selanjutnya
           
        }
       
            
        if (transform.position == nextPosition & VRCamera != null) {
            lastPosition = transform.position;
            lastRotation = transform.rotation;
            int random = Random.Range(0, 2);
            if (random == 0)
            {
                timeStopped = Time.time;
                stop = true;
            }
            else 
            {
                nextPosition = VRCamera.generateSpawnCircle()+VRCamera.transform.position;
                nextRotation = Quaternion.LookRotation(nextPosition-lastPosition).normalized;
                nextRotation *= Quaternion.Euler(30, 0, 0);// add 90 angle
            }
           
        }

       if (Time.time - timeStopped >= 2)
       {
           
            stop = false;
       }

        if (Time.time - startTime >= butterflyDespawnTime && VRCamera!=null)  
        {
            Destroy(gameObject);
            SpawnButterfly.instance.currentButterfly--;
        
        }
        
        
    }


}
