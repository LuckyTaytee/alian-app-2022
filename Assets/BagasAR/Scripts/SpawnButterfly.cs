using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnButterfly : MonoBehaviour
{
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

    private void Awake()
    {
        instance = this; 
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
        Vector3 spawnCircle = Random.insideUnitSphere;

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
                     Instantiate(array[spawnRareRandomly], spawnPosition, Quaternion.identity);
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
                    Instantiate(array[spawnUncommonRandomly], spawnPosition, Quaternion.identity);
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
                    Instantiate(array[spawnCommonRandomly], spawnPosition, Quaternion.identity);
                    currentButterfly += 1;
                    break;
                }
             }
         } 




        //posisi di spawn position, rotation identity karena kita udah ngeset di enemy script jadi quaternion.identity
    }

    public Vector3 generateSpawnCircle(){
        Vector3 random = Random.onUnitSphere * spawnDistance;
        random.y = Mathf.Abs(random.y); ;
        return random; 
    }
}
