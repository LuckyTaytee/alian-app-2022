using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpawnButterfly : MonoBehaviour
{

    public PlayerData player;
    public float spawnDistance;
    public float chanceToSpawnStart; //guaranteed spawn dalam 10*timetospawn detik, tiap detik chance nambah 10 persen
    public float timeToSpawn; //berapadetik hingga spawn (misal 1 detik)
    public float spawnChanceModifier;
    public float maxButterfly;
    public float currentButterfly;

    public float butterfly1Rarity;
    public float butterfly2Rarity;
    public float butterfly3Rarity;
  
    public GameObject butterfly1Prefab;
    public GameObject butterfly2Prefab;
    public GameObject butterfly3Prefab;
    public GameObject butterfly4Prefab;
    public GameObject butterfly5Prefab;
    public GameObject butterfly6Prefab;

    public static SpawnButterfly instance;
    
    public float spawnChance;
    private float lastSpawnTime;
    public float spawnRate; //random 1-3 butterfly dalam sekali spawn
    public float gacha;
    private string saveFile;

    private void OnDestroy()
    {
        writeFile();
    }
    private void Awake()
    {
        instance = this; 
        saveFile = Application.persistentDataPath + "/gamedata.json";
        Debug.Log(saveFile);
        if (File.Exists(saveFile))
        {
            player = ReadFile();
            Debug.Log("player data diload" + player);
        }
        else
        {
            //Instansiasi player data baru 
            player = new PlayerData();
        }
    }
    // Start is called before the first frame update
    void Start()
    { 
       
        //awal mula spawn chance
        spawnChance = chanceToSpawnStart;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - lastSpawnTime >= timeToSpawn) 
        {
            float randSpawnChance = Random.Range(1, 101); //generate random untuk spawn
            spawnRate = Random.Range(1, 4); //generate random untuk jumlah butterfly yang akan di spawn
            if (randSpawnChance >= (100 - spawnChance))
            {
                for (int i = 0; i < spawnRate; i++)
                {
                    lastSpawnTime = Time.time;
                    spawnChance = chanceToSpawnStart; //reset setiap udah spawn
                    if (currentButterfly < maxButterfly)
                    {
                        Spawn();
                    }
                  
                }

            }
            else 
            {
                lastSpawnTime = Time.time;
                spawnChance += spawnChanceModifier; //menambahkan spawnchance modifier

            }
            
        }
       

    }

    void Spawn()
    {
       
        //spawn circle
        Vector3 spawnCircle = Random.onUnitSphere;

        //y biar tidak negatif
        spawnCircle.y = Mathf.Abs(spawnCircle.y);

        //Spawn position
        Vector3 spawnPosition = transform.position + (spawnCircle * spawnDistance);
        //spawn posisi dapet posisi shooter core + spawnCircle (yaitu random di unit sphere) + distancenya ini multiplier

        
        for (int i = 0; i < 3; i++) {

             if (i == 0)
             {
                gacha = Random.Range(1, 101);
                if (gacha >= (100 - butterfly1Rarity)) 
                 {
                    GameObject[] array = new GameObject[2];
                    array[0] = butterfly1Prefab;
                    array[1] = butterfly2Prefab;
                    int spawnRareRandomly = Random.Range(0, 2);
                    GameObject butterfly = Instantiate(array[spawnRareRandomly], spawnPosition, Quaternion.identity);
                    EventTrigger eventTrigger = butterfly.AddComponent<EventTrigger>(); //add event trigger programmatically
                    EventTrigger.Entry entry = new EventTrigger.Entry();
                    entry.eventID = EventTriggerType.PointerDown;
                    entry.callback.AddListener((data) => { OnPointerDownDelegate(butterfly); });
                    eventTrigger.triggers.Add( entry );
                    currentButterfly += 1;
                     break;
                 }
             }
             else if (i == 1) 
             {
                gacha = Random.Range(1, 101);
                if (gacha >= (100 - butterfly2Rarity))
                 {
                    GameObject[] array = new GameObject[2];
                    array[0] = butterfly3Prefab;
                    array[1] = butterfly4Prefab;
                    int spawnUncommonRandomly = Random.Range(0, 2);
                    GameObject butterfly = Instantiate(array[spawnUncommonRandomly], spawnPosition, Quaternion.identity);
                    EventTrigger eventTrigger = butterfly.AddComponent<EventTrigger>(); //add event trigger programmatically
                    EventTrigger.Entry entry = new EventTrigger.Entry();
                    entry.eventID = EventTriggerType.PointerDown;
                    entry.callback.AddListener((data) => { OnPointerDownDelegate(butterfly); });
                    eventTrigger.triggers.Add(entry);
                    currentButterfly += 1;
                    break;
                }
             }
             else if (i == 2)
             {
                gacha = Random.Range(1, 101);
                if (gacha >= (100 - butterfly3Rarity))
                 {
                    GameObject[] array = new GameObject[2];
                    array[0] = butterfly5Prefab;
                    array[1] = butterfly6Prefab;
                    int spawnCommonRandomly = Random.Range(0, 2);
                    GameObject butterfly = Instantiate(array[spawnCommonRandomly], spawnPosition, Quaternion.identity);
                    EventTrigger eventTrigger = butterfly.AddComponent<EventTrigger>(); //add event trigger programmatically
                    EventTrigger.Entry entry = new EventTrigger.Entry();
                    entry.eventID = EventTriggerType.PointerDown;
                    entry.callback.AddListener((data) => { OnPointerDownDelegate(butterfly); });
                    eventTrigger.triggers.Add(entry);
                    currentButterfly += 1;
                    break;
                }
             }
         } 




        //posisi di spawn position, rotation identity karena kita udah ngeset di enemy script jadi quaternion.identity
    }

    public void OnPointerDownDelegate(GameObject butterfly) 
    {
        ButterflyBehavior selectedButterfly = butterfly.GetComponent<ButterflyBehavior>();
        if (selectedButterfly.tag == "Butterfly1")
        {
            player.butterfly1 = true;
            Debug.Log("Butterfly1 is true");
            writeFile();
        }
        if (selectedButterfly.tag == "Butterfly2")
        {
            player.butterfly2 = true;
            Debug.Log("Butterfly2 is true");
            writeFile();
        }
        if (selectedButterfly.tag == "Butterfly3")
        {
            player.butterfly3 = true;
            Debug.Log("Butterfly3 is true");
            writeFile();
        }
        if (selectedButterfly.tag == "Butterfly4")
        {
            player.butterfly4 = true;
            Debug.Log("Butterfly4 is true");
            writeFile();
        }
        if (selectedButterfly.tag == "Butterfly5")
        {
            player.butterfly5 = true;
            Debug.Log("Butterfly5 is true");
            writeFile();
        }
        if (selectedButterfly.tag == "Butterfly6")
        {
            player.butterfly6 = true;
            Debug.Log("Butterfly6 is true");
            writeFile();
        }

        Destroy(butterfly);
        currentButterfly -= 1;
    }

    public Vector3 generateSpawnCircle(){
        Vector3 random = Random.onUnitSphere * spawnDistance;
        random.y = Mathf.Abs(random.y); ;
        return random; 
    }

    public void writeFile()
    {
        // Serialize the object into JSON and save string.
        string jsonString = JsonUtility.ToJson(player);

        // Write JSON to file.
        File.WriteAllText(saveFile, jsonString);
        Debug.Log(jsonString);
    }

    public PlayerData ReadFile() 
    {
        string fileContents = File.ReadAllText(saveFile);
        Debug.Log(fileContents);

        // Deserialize the JSON data 
        //  into a pattern matching the GameData class.
        return JsonUtility.FromJson<PlayerData>(fileContents);
    }
}
