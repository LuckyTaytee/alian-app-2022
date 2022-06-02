using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PembelajaranARSessionScript : MonoBehaviour
{
    public PlayerData player;
    public string saveFile;
    public static PembelajaranARSessionScript instance;
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
      
        placementIndicator = FindObjectOfType<PlacementIndicatorScript>();
    }

    // Update is called once per frame
    void Update()
    {
        pointerController();
        //input touch count untuk controller hit
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("Something Hit");
               //ini untuk deteksi collision
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
                
            }

           
        }
    }

    public void placeEgg() {
        //ini dari UI tombol play
        GameObject spawnedObject = Instantiate(objectToSpawn,
            placementIndicator.transform.position, placementIndicator.transform.rotation);
    }

    // ini untuk objectToSpawn jadi kita ngeset object buat dispawnnya
    public void selectFirst() {
        
        objectToSpawn = Resources.Load("Prefabs/PlaceholderButterfly1") as GameObject;
    }

    public PlayerData ReadFile()
    {
        string fileContents = File.ReadAllText(saveFile);
        Debug.Log(fileContents);

        // Deserialize the JSON data 
        //  into a pattern matching the GameData class.
        return JsonUtility.FromJson<PlayerData>(fileContents);
    }

    //ngecek pointernya enabled atau enggak, maunya kita spawn si button untuk start
    public void pointerController() 
    {
        //if pointer tidak aktif, maka display tulisan, arahkan pointer ke ruang kosong
        //if pointer is aktif dan bool sceneBerjalan=false, maka display button start, tapi button start itu sendiri kan
        //else gausah ngapa ngapain
    }

    
}


