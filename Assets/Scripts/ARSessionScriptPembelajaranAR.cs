using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ARSessionScriptPembelajaranAR : MonoBehaviour
{
    public static ARSessionScriptPembelajaranAR instance;
    private PlacementIndicatorScript placementIndicator;
    private GameObject objectToSpawn;
    private GameObject spawnedObject;
    public GameObject collectionButton;
    private bool rotateLeftPressed = false;
    private bool rotateRightPressed = false;
    private bool modelPlaced = false;

    public PanelInformasiBehavior panelInformasi;
    public GameObject canvas;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
       
        panelInformasi = canvas.transform.Find("Panel Petunjuk").GetComponent<PanelInformasiBehavior>();
        placementIndicator = FindObjectOfType<PlacementIndicatorScript>();
        togglePanel();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if( panelInformasi.gameObject.activeSelf==false){
                     if (hit.transform.tag == "placementIndicator" && !modelPlaced)
                {
                    Debug.Log("placementIndicator");
                    LifeCyclePhase1();
                    modelPlaced = true;
                }

                if (hit.transform.tag == "lifecycle1")
                {
                    hit.transform.GetComponent<LifecycleMinigame1>().EggClicked();
                }

                if (hit.transform.tag == "leaf")
                {
                    LifecycleMinigame2.instance.clickLeaf(hit.transform.position);
                }
                }
               

            }
            else if (!rotateLeftPressed && !rotateRightPressed)
            {


            }

        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.transform.tag);

                if( panelInformasi.gameObject.activeSelf==false){
                     if (hit.transform.tag == "placementIndicator" && !modelPlaced)
                {
                    Debug.Log("placementIndicator");
                    LifeCyclePhase1();
                    modelPlaced = true;
                }

                if (hit.transform.tag == "lifecycle1")
                {
                    hit.transform.GetComponent<LifecycleMinigame1>().EggClicked();
                }

                if (hit.transform.tag == "leaf")
                {
                    LifecycleMinigame2.instance.clickLeaf(hit.transform.position);
                }
                }


            }
            else if (!rotateLeftPressed && !rotateRightPressed)
            {


            }

        }
        if (rotateLeftPressed) {
            rotateLeft();
        }

        if (rotateRightPressed) {
            rotateRight();
        }

        // if (spawnedObject != null)
        // {
        //   spawnedObject.transform.position = new Vector3(placementIndicator.transform.position.x, placementIndicator.transform.position.y + 0.25f, placementIndicator.transform.position.z);
        // }
        // else {
        //     placeButterfly();
        // }
    }

    public void ResetPlacement()
    {
        SceneManager.LoadScene("Pembelajaran AR");
    }

    public void pressButtonRotateLeft()
    {
        rotateLeftPressed = true;
    }
    public void unpressButtonRotateLeft()
    {
        rotateLeftPressed = false;
    }
    public void rotateLeft()
    {
        if (spawnedObject != null)
        {
            spawnedObject.transform.Rotate(0, 4f, 0);
        }
    }
    public void rotateRight()
    {
        if (spawnedObject != null)
        {
            spawnedObject.transform.Rotate(0, -4f, 0);
        }
    }

    public void pressButtonRotateRight() {
        rotateRightPressed = true;
    }

    public void unpressButtonRotateRight() {
        rotateRightPressed = false;
    }

    public void LifeCyclePhase1()
    {
        objectToSpawn = Resources.Load("Prefabs/Lifecycle1") as GameObject;
        if (spawnedObject != null)
        {
            Destroy(spawnedObject);
        }
        Vector3 position = new Vector3(placementIndicator.transform.position.x, placementIndicator.transform.position.y, placementIndicator.transform.position.z);
        spawnedObject = Instantiate(objectToSpawn, position, placementIndicator.transform.rotation);
        panelInformasi = canvas.transform.Find("Panel Telur").GetComponent<PanelInformasiBehavior>();
        togglePanel();
    }

    public void LifeCyclePhase2()
    {
        Vector3 position = spawnedObject.transform.position;
        Quaternion rotation = spawnedObject.transform.rotation;
        Destroy(spawnedObject);
        objectToSpawn = Resources.Load("Prefabs/Lifecycle2") as GameObject;
        spawnedObject = Instantiate(objectToSpawn, position, Quaternion.Euler(0, Random.Range(0, 180), 0));
        panelInformasi = canvas.transform.Find("Panel Ulat").GetComponent<PanelInformasiBehavior>();
        togglePanel();

    }

    public void LifeCyclePhase3()
    {
        Vector3 position = spawnedObject.transform.position;
        Quaternion rotation = spawnedObject.transform.rotation;
        Destroy(spawnedObject);
        objectToSpawn = Resources.Load("Prefabs/Lifecycle3") as GameObject;
        spawnedObject = Instantiate(objectToSpawn, position, Quaternion.Euler(0, Random.Range(0, 180), 0));
        panelInformasi = canvas.transform.Find("Panel Kepompong").GetComponent<PanelInformasiBehavior>();
        togglePanel();

    }

    public void LifeCyclePhase4()
    {
        Vector3 position = spawnedObject.transform.position;
        Destroy(spawnedObject);
        objectToSpawn = Resources.Load("Prefabs/Lifecycle4") as GameObject;
        spawnedObject = Instantiate(objectToSpawn, position, Quaternion.identity);
        panelInformasi = canvas.transform.Find("Panel Kupu-Kupu").GetComponent<PanelInformasiBehavior>();
        togglePanel();

    }

    public void togglePanel() {
        panelInformasi.TogglePanel();
    }
}


