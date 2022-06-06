using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereChanger : MonoBehaviour {
    //id dimana tempat dia berada
    public int currentID = 1;
    public bool currentSpawnableState = true;
    public float currentMaxButterfly = 3;
    //This object should be called 'Fader' and placed over the camera
    GameObject m_Fader;

    //This ensures that we don't mash to change spheres
    bool changing = false;


    void Awake()
    {

        //Find the fader object
        m_Fader = GameObject.Find("Fader");

        //Check if we found something
        if (m_Fader == null)
            Debug.LogWarning("No Fader object found on camera.");

    }


    public void ChangeSphere(GameObject nextSphere)
    {
        if(changing != true)
        //Start the fading process
        StartCoroutine(FadeCamera(nextSphere));
        currentID = nextSphere.GetComponent<SphereScript>().ID;
        currentSpawnableState = nextSphere.GetComponent<SphereScript>().spawnable;
        currentMaxButterfly = nextSphere.GetComponent<SphereScript>().maxButterfly;
        gameObject.GetComponent<SpawnButterfly>().allowSpawn = currentSpawnableState;
        gameObject.GetComponent<SpawnButterfly>().maxButterfly = currentMaxButterfly;
    }


    IEnumerator FadeCamera(GameObject nextSphere)
    {
        changing = true;
        Debug.Log("Changing");

        //Ensure we have a fader object
        if (m_Fader != null)
        {
            //Fade the Quad object in and wait 0.75 seconds
            yield return StartCoroutine(FadeIn(0.75f, m_Fader.GetComponent<Renderer>().material));

            //Change the camera position
            Camera.main.transform.parent.position = nextSphere.transform.position;

            //Fade the Quad object out 
            yield return StartCoroutine(FadeOut(0.75f, m_Fader.GetComponent<Renderer>().material));
        }
        else
        {
            //No fader, so just swap the camera position
            Camera.main.transform.parent.position = nextSphere.transform.position;
        }

        changing = false;
    }


    IEnumerator FadeOut(float time, Material mat)
    {
        //While we are still visible, remove some of the alpha colour
        while (mat.color.a > 0.0f)
        {
            mat.color = new Color(mat.color.r, mat.color.g, mat.color.b, mat.color.a - (Time.deltaTime / time));
            if (mat.color.a < 0.0f)
            {
                mat.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
                yield return null;
            }
            yield return null;
        }
    }


    IEnumerator FadeIn(float time, Material mat)
    {
        //While we aren't fully visible, add some of the alpha colour
        while (mat.color.a < 1.0f)
        {
            mat.color = new Color(mat.color.r, mat.color.g, mat.color.b, mat.color.a + (Time.deltaTime / time));
            if (mat.color.a > 1.0f)
            {
                mat.color = new Color(0.0f, 0.0f, 0.0f, 1.0f);
                yield return null;
            }
            yield return null;
        }
    }


}
