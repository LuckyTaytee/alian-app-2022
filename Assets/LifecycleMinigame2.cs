using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifecycleMinigame2 : MonoBehaviour
{
    public Image progressBarImage;
    public GameObject leaf;
    public GameObject collector;
    public Vector3 leafPosition;
    public static LifecycleMinigame2 instance;
    public int leafAmount = 0;
    public int maxLeaf;
    public float outerRadius;
    public float innerRadius;
    public float movementSpeed;
    public float progress;
    public float timer;
    public float timeToSpawn;
    public float firstScale;
    public float toScale;
    bool isScaling = false;

    private void Awake()
    {
        instance = this; 
    }

    // Start is called before the first frame update
    void Start()
    {
        firstScale = transform.localScale.x;
        leafPosition = transform.position;
        ProgressBar.instance.minigameObject = gameObject;
        progressBarImage = ProgressBar.instance.transform.Find("Image").Find("Image").GetComponent<Image>();
        progressBarImage.fillAmount = 0;
        transform.Find("Caterpillar P. Memnon").GetComponent<Animator>().speed = 0.1f;
        collector = new GameObject();
    }

    void spawnLeaf() {
        float ratio = innerRadius / outerRadius;
        float radius = Mathf.Sqrt(Random.Range(ratio * ratio, 1f)) * outerRadius;
        Vector3 spawnPoint = Random.insideUnitCircle.normalized * radius; 

        spawnPoint.x += PlacementIndicatorScript.instance.transform.position.x;
        spawnPoint.z = spawnPoint.y + PlacementIndicatorScript.instance.transform.position.z;
        spawnPoint.y = 0;
        spawnPoint.y += PlacementIndicatorScript.instance.transform.position.y;
        GameObject spawnedLeaf = Instantiate(leaf, spawnPoint, Random.rotation);
        spawnedLeaf.transform.SetParent(collector.transform);
        leafAmount++;
    }

    public void clickLeaf(Vector3 leafPosition) {
        this.leafPosition = leafPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
        if ((leafPosition-transform.position)!=Vector3.zero)
        {
            Quaternion nextRotation = Quaternion.LookRotation(leafPosition - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, nextRotation, (float)(Time.deltaTime * movementSpeed * 20));
            transform.position = Vector3.MoveTowards(transform.position, leafPosition, (Time.deltaTime * movementSpeed));
        }
       
        timer += Time.deltaTime;
        if (timer >= timeToSpawn) {
            timer -= timeToSpawn;
            if (leafAmount < maxLeaf)
            {

                int randomNumber = Random.Range(1, 101);
                if (randomNumber >= 50)
                {

                    spawnLeaf();
                }

            }

        }

        if (progress >= 100) 
        {
            StartCoroutine(WaitUntilNextPhase(3f));
        }
        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag =="leaf")
        {
            Destroy(other.gameObject);
            leafAmount--;
            progress += 20f;
            float scaleProgress = (progress / 100) * (toScale - firstScale);
            Vector3 scaleVector = new Vector3(firstScale + scaleProgress, firstScale +scaleProgress, firstScale + scaleProgress);
            progressBarImage.fillAmount = Mathf.Clamp(progress / 100, 0, 1f);
            StartCoroutine(ScaleUp(transform, scaleVector, 5f));
        }
    }

    void NextPhase() 
    {
        Debug.Log("NextPhase");
        ARSessionScriptPembelajaranAR.instance.LifeCyclePhase3();
    }

    //scale
    IEnumerator ScaleUp(Transform transform, Vector3 upScale, float duration)
    {
        
        if (isScaling)
        {
            yield break; ///exit if this is still running
        }
        isScaling = true;

        float counter = 0;

        //Get the current scale of the object to be moved
        Vector3 startScaleSize = transform.localScale;
        Vector3 startScaleCollider = transform.GetComponent<BoxCollider>().transform.localScale;

        while (counter < duration)
        {
            counter += Time.deltaTime;
            transform.localScale = Vector3.Lerp(startScaleSize, upScale, counter / duration);
            transform.GetComponent<BoxCollider>().transform.localScale = Vector3.Lerp(startScaleCollider, upScale, counter / duration);
            yield return null;
        }

        isScaling = false;
    }
    // ...
    IEnumerator WaitUntilNextPhase(float duration)
    {
        float timer = 0;
        while (timer < duration)
        {
            timer += Time.deltaTime;
            yield return null;
        }
        NextPhase();
    
    }


}
