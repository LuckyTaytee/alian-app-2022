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
    public GameObject collectionButton;
    public GameObject collectionCanvas;
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
        checkUnlocked();
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
                Debug.Log("Something Hit");
                if (hit.collider.tag == "Butterfly1" || hit.collider.tag == "Butterfly2" || hit.collider.tag == "Butterfly3" || hit.collider.tag == "Butterfly4" || hit.collider.tag == "Butterfly5" || hit.collider.tag == "Butterfly6")
                {
                    ButterflyBehavior selectedButterfly = hit.collider.GetComponent<ButterflyBehavior>();

                    if (selectedButterfly != null)
                    {
                        Debug.Log("Butterfly is hit");
                        selectedButterfly.ActivateButton(); 
                        Destroy(selectedButterfly.gameObject);
                    }
                }

            }
            else
            {
                placeButterfly();
            }

           
        }
    }

    public void placeButterfly() {
        GameObject spawnedObject = Instantiate(objectToSpawn,
            placementIndicator.transform.position, placementIndicator.transform.rotation);
    }

    public void goToCollection()
    {
        collectionButton.SetActive(false);
        collectionCanvas.SetActive(true);
    }

    public void goBack() {
        collectionButton.SetActive(true);
        collectionCanvas.SetActive(false);
      
    }

    public void selectFirst() {
        
        objectToSpawn = Resources.Load("Prefabs/PlaceholderButterfly1") as GameObject;
    }

    public void selectSecond() {
        objectToSpawn = Resources.Load("Prefabs/PlaceholderButterfly2") as GameObject;
    }

    public void selectThird() {
        objectToSpawn = Resources.Load("Prefabs/PlaceholderButterfly3") as GameObject;
    }

    public void selectFourth() {
        objectToSpawn = Resources.Load("Prefabs/PlaceholderButterfly4") as GameObject;
    }

    public void selectFifth() {
        objectToSpawn = Resources.Load("Prefabs/PlaceholderButterfly5") as GameObject;
    }

    public void selectSixth() {
        objectToSpawn = Resources.Load("Prefabs/PlaceholderButterfly6") as GameObject;
    }

    public PlayerData ReadFile()
    {
        string fileContents = File.ReadAllText(saveFile);
        Debug.Log(fileContents);

        // Deserialize the JSON data 
        //  into a pattern matching the GameData class.
        return JsonUtility.FromJson<PlayerData>(fileContents);
    }

    public void checkUnlocked() 
    {

        UnityEngine.UI.Button button;
        if (player.butterfly1)
        {
            button = collectionCanvas.transform.Find("SelectFirstModel").GetComponent<UnityEngine.UI.Button>();
            button.interactable = true;
        }
        if (player.butterfly2)
        {
            button = collectionCanvas.transform.Find("SelectSecondModel").GetComponent<UnityEngine.UI.Button>();
            button.interactable = true;
        }
        if (player.butterfly3)
        {
            button = collectionCanvas.transform.Find("SelectThirdModel").GetComponent<UnityEngine.UI.Button>();
            button.interactable = true;
        }
        if (player.butterfly4)
        {
            button = collectionCanvas.transform.Find("SelectFourthModel").GetComponent<UnityEngine.UI.Button>();
            button.interactable = true;
        }
        if (player.butterfly5)
        {
            button = collectionCanvas.transform.Find("SelectFifthModel").GetComponent<UnityEngine.UI.Button>();
            button.interactable = true;
        }
        if (player.butterfly6)
        {
            button = collectionCanvas.transform.Find("SelectSixthModel").GetComponent<UnityEngine.UI.Button>();
            button.interactable = true;
        }
    }
}


