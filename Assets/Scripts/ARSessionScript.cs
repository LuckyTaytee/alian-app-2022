using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ARSessionScript : MonoBehaviour
{
    public PlayerData player;
    public string saveFile;
    public static ARSessionScript instance;
    private PlacementIndicatorScript placementIndicator;
    private GameObject objectToSpawn;
    private GameObject spawnedObject;
    public GameObject collectionButton;
    public GameObject rotateCanvas;
    public GameObject collectionCanvas;
    private bool rotateLeftPressed = false;
    private bool rotateRightPressed = false; 
    private void Awake()
    {
        saveFile = Application.persistentDataPath + "/gamedata.json";
        instance = this; 
    }
    // Start is called before the first frame update
    void Start()
    {
        if (File.Exists(saveFile))
        {
            player = ReadFile();
        }
        else 
        {
            player = new PlayerData();
        }
        checkForModels();
        placementIndicator = FindObjectOfType<PlacementIndicatorScript>();
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
                if (hit.transform.tag == "butterfly")
                {
                    setSpeed();
                }

                if (hit.transform.tag == "placementIndicator") 
                {
                    placeButterfly();
                }
            }
            else if (!rotateLeftPressed&&!rotateRightPressed)
            {
               

            }

        }

        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.transform.tag);
                if (hit.transform.tag == "butterfly")
                {
                    setSpeed();
                }

                if (hit.transform.tag == "placementIndicator")
                {
                    placeButterfly();
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

    public void placeButterfly() {
        if (spawnedObject != null) 
        {
            Destroy(spawnedObject);
        }
        Vector3 position = new Vector3(placementIndicator.transform.position.x, placementIndicator.transform.position.y + 0.25f, placementIndicator.transform.position.z);
        spawnedObject = Instantiate(objectToSpawn, position, placementIndicator.transform.rotation);
        spawnedObject.transform.tag = "butterfly";
        rotateCanvas.SetActive(true);
        rotateCanvas.transform.position = new Vector3(spawnedObject.transform.position.x, spawnedObject.transform.position.y + 0.25f, spawnedObject.transform.position.z);
        
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

    public void setSpeed() {
        if (spawnedObject != null) 
        {
            if (spawnedObject.GetComponent<Animator>().speed != 0)
            {
                spawnedObject.GetComponent<Animator>().speed = 0;
            } 
            else 
            {
                spawnedObject.GetComponent<Animator>().speed = 1 + (spawnedObject.GetComponent<ButterflyBehavior>().butterflySpeed - 5) / 4;
            }
          
        }
     
    }

    public PlayerData ReadFile()
    {
        string fileContents = File.ReadAllText(saveFile);
        Debug.Log(fileContents);

        // Deserialize the JSON data 
        //  into a pattern matching the GameData class.
        return JsonUtility.FromJson<PlayerData>(fileContents);
    }

    public void checkForModels() 
    {
        objectToSpawn = Resources.Load(player.selectedButterfly) as GameObject;
        Debug.Log(player.selectedButterfly);
    }
}


