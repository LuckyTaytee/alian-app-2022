using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
public class PlacementIndicatorScript : MonoBehaviour
{
    private ARRaycastManager rayManager; //variabel untuk menyimpan raycastmanager
    private GameObject placementIndicator; //variabel menyimpan gameobject atau si placement indicator
    public static PlacementIndicatorScript instance;
    // Start is called before the first frame update
    void Start()
    {
        //get the components
        rayManager = FindObjectOfType<ARRaycastManager>();
        placementIndicator = transform.GetChild(0).gameObject;
        //hide the placement indicator visual
       // placementIndicator.SetActive(true);
        //instantiate placement indicator supaya bisa diakses di script/komponen yang lain
    }
    // Update is called once per frame
    void Update()
    {
        //list hits yang dilakukan oleh raycast, hits tersebut diurutkan terdekat terjauh berdasarkan indeks
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        //melakukan raycast, raycast(touch position, hits, trackable types)
        rayManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.PlaneEstimated);
        //kenapa screen width dan height dibagi dua, karena kita ingin tengah tengah screennya di hit, terus trackable type plane, berarti kita ingin melakukan tracking terhadap ar plane
        //if hit an AR Plane, update position and rotation
        if (hits.Count > 0)
        {
            transform.position = hits[0].pose.position;
            transform.rotation = hits[0].pose.rotation;
           // if (!placementIndicator.activeInHierarchy)
           // {
           //     placementIndicator.SetActive(true);
           // }
        }
    }

    private void Awake()
    {
        instance = this;    
    }
}