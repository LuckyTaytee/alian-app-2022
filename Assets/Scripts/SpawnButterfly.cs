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
    public bool allowSpawn = true;

    public GameObject[] commonButterfly; //kupu yang sering muncul
    public GameObject[] uncommonButterfly; //kupu yang agak jarang muncul
    public GameObject[] rareButterfly;// kupu yang langka
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
        //set instance dari spawn butterfly supaya kita bisa mengakses script spawn butterfly tersebut
        instance = this;
        //melakukan pembuatan path saveFile
        saveFile = Application.persistentDataPath + "/gamedata.json";
        
        //conditional, apabila savefile sudah ada, maka akan mengassign variabel player dengan hasil dari file yang sudah di Read
        if (File.Exists(saveFile))
        {
            player = ReadFile();
            Debug.Log("player data diload" + player);
        }
        else
        {
            //Instansiasi player data baru apabila file belum ada
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
        //kondisi spawn akan muncul ketika allow saja, kalau tidak allow spawn maka tidak akan muncul
        if (allowSpawn) 
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

    }

    void Spawn()
    {
       
        //spawn circle
        Vector3 spawnCircle = Random.onUnitSphere;

        //y biar tidak negatif
        spawnCircle.y = (float) (Mathf.Abs(spawnCircle.y) * 0.4);

        //Spawn position
        Vector3 spawnPosition = transform.position + (spawnCircle * spawnDistance);
        //spawn posisi dapet posisi shooter core + spawnCircle (yaitu random di unit sphere) + distancenya ini multiplier

        
        for (int i = 0; i < 3; i++)
        {

            //pengecekan kupu-kupu umum
            if (i == 0)
            {
                //gacha adalah random number diantara 1-100
                gacha = Random.Range(1, 101);
                //apabila gacha melebihi atau samadengan 100 dikurangi kelangkaan kupu-kupu umum, maka akan memunculkan kupu-kupu
                if (gacha >= (100 - butterfly1Rarity))
                {
                    //memunculkan kupu-kupu sebanyak 8 jenis (array 0 hingga array 7)
                    int spawnCommonRandomly = Random.Range(0, 8);
                    //instansiasi kupu-kupu
                    GameObject butterfly = Instantiate(commonButterfly[spawnCommonRandomly], spawnPosition, Quaternion.identity);
                    EventTrigger eventTrigger = butterfly.AddComponent<EventTrigger>(); //add event trigger programmatically
                    EventTrigger.Entry entry = new EventTrigger.Entry();
                    entry.eventID = EventTriggerType.PointerDown;
                    entry.callback.AddListener((data) => { OnPointerDownDelegate(butterfly); });
                    eventTrigger.triggers.Add(entry);
                    currentButterfly += 1;
                    break;
                }
            }
            //pengecekan kemunculan kupu-kupu jarang
            else if (i == 1) 
             {
                gacha = Random.Range(1, 101);
                if (gacha >= (100 - butterfly2Rarity))
                 {
                    int spawnUncommonRandomly = Random.Range(0, 6);
                    GameObject butterfly = Instantiate(uncommonButterfly[spawnUncommonRandomly], spawnPosition, Quaternion.identity);
                    EventTrigger eventTrigger = butterfly.AddComponent<EventTrigger>(); //add event trigger programmatically
                    EventTrigger.Entry entry = new EventTrigger.Entry();
                    entry.eventID = EventTriggerType.PointerDown;
                    entry.callback.AddListener((data) => { OnPointerDownDelegate(butterfly); });
                    eventTrigger.triggers.Add(entry);
                    currentButterfly += 1;
                    break;
                }
             }
            //pengecekan kemunculan kupu-kupu jarang
             else if (i == 2)
             {
                gacha = Random.Range(1, 101);
                if (gacha >= (100 - butterfly3Rarity))
                 {
                    int spawnRareRandomly = Random.Range(0, 4);
                    GameObject butterfly = Instantiate(rareButterfly[spawnRareRandomly], spawnPosition, Quaternion.identity);
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
        if (selectedButterfly.tag == "acraeaTerpsicore")
        {
            player.acraeaTerpsicore = true;
          
        }
        if (selectedButterfly.tag == "attacusAtlas")
        {
            player.attacusAtlas = true;
        }
        if (selectedButterfly.tag == "danausChrysippus")
        {
            player.danausChrysippus = true;
        }
        if (selectedButterfly.tag == "doleschalliaBisaltide")
        {
            player.doleschalliaBisaltide = true;
        }
        if (selectedButterfly.tag == "doleschalliaBisaltide")
        {
            player.doleschalliaBisaltide = true;
        }
        if (selectedButterfly.tag == "euploeaMulciber")
        {
            player.euploeaMulciber = true;
        }
        if (selectedButterfly.tag == "euploeaMulciber")
        {
            player.euploeaMulciber = true;
        }
        if (selectedButterfly.tag == "graphiumAgamemnon")
        {
            player.graphiumAgamemnon = true;
        }
        if (selectedButterfly.tag == "graphiumDoson")
        {
            player.graphiumDoson = true;
        }
        if (selectedButterfly.tag == "graphiumSarpedon")
        {
            player.graphiumSarpedon = true;
        }
        if (selectedButterfly.tag == "hypolimnasBolina")
        {
            player.hypolimnasBolina = true;
        }
        if (selectedButterfly.tag == "hypolimnasMissipus")
        {
            player.hypolimnasMissipus = true;
        }
        if (selectedButterfly.tag == "losariaCoon")
        {
            player.losariaCoon = true;
        }
        if (selectedButterfly.tag == "pachlioptaAristolochiae")
        {
            player.pachlioptaAristolochiae = true;
        }
        if (selectedButterfly.tag == "papilioDemoleus")
        {
            player.papilioDemoleus = true;
        }
        if (selectedButterfly.tag == "papilioHelenus")
        {
            player.papilioHelenus = true;
        }
        if (selectedButterfly.tag == "papilioMemnon")
        {
            player.papilioMemnon = true;
        }
        if (selectedButterfly.tag == "papilioMemnon")
        {
            player.papilioMemnon = true;
        }
        if (selectedButterfly.tag == "parthenosSylvia")
        {
            player.parthenosSylvia = true;
        }
        if (selectedButterfly.tag == "politesPeckius")
        {
            player.politesPeckius = true;
        }
        if (selectedButterfly.tag == "troidesHelena")
        {
            player.troidesHelena = true;
        }
        Debug.Log(selectedButterfly.tag);
        writeFile();
        Destroy(butterfly);
        currentButterfly -= 1;
    }

    public Vector3 generateSpawnCircle(){
        Vector3 spawnCircle = Random.insideUnitSphere;
        //y biar tidak negatif
        spawnCircle.y = (float)(Mathf.Abs(spawnCircle.y) * 0.4);
        spawnCircle *= spawnDistance;
        return spawnCircle; 
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
