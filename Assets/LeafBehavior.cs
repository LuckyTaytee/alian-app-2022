using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafBehavior : MonoBehaviour
{
    public float timeToDespawn;
    // Start is called before the first frame update
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeToDespawn -= Time.deltaTime;
        if (timeToDespawn <= 0) {
            Destroy(transform.gameObject);
            LifecycleMinigame2.instance.leafAmount--;
        }
    }
}
