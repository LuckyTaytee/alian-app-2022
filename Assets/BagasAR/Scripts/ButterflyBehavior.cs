using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyBehavior : MonoBehaviour
{
    public static ButterflyBehavior instance;
    public static SpawnButterfly ARCamera;
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
        ARCamera = SpawnButterfly.instance;
        lastPosition = transform.position;
        nextPosition = ARCamera.generateSpawnCircle();
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
                nextPosition = ARCamera.generateSpawnCircle();
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
        UnityEngine.UI.Button button;
        if (tag == "Butterfly1")
        {
            button = parentCanvas.transform.Find("CanvasCollection").Find("SelectFirstModel").GetComponent<UnityEngine.UI.Button>();
            button.interactable = true;
        }
        if (tag == "Butterfly2") {
            button = parentCanvas.transform.Find("CanvasCollection").Find("SelectSecondModel").GetComponent<UnityEngine.UI.Button>();
            button.interactable = true;
        }
        if (tag == "Butterfly3")
        {
            button = parentCanvas.transform.Find("CanvasCollection").Find("SelectThirdModel").GetComponent<UnityEngine.UI.Button>();
            button.interactable = true;
        }
        if (tag == "Butterfly4")
        {
            button = parentCanvas.transform.Find("CanvasCollection").Find("SelectFourthModel").GetComponent<UnityEngine.UI.Button>();
            button.interactable = true;
        }
        if (tag == "Butterfly5")
        {
            button = parentCanvas.transform.Find("CanvasCollection").Find("SelectFifthModel").GetComponent<UnityEngine.UI.Button>();
            button.interactable = true;
        }
        if (tag == "Butterfly6")
        {
            button = parentCanvas.transform.Find("CanvasCollection").Find("SelectSixthModel").GetComponent<UnityEngine.UI.Button>();
            button.interactable = true;
        }

        

    }


}
