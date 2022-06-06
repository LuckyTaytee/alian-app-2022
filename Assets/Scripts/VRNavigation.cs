using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class VRNavigation : MonoBehaviour
{
    int sceneIndex;
    // Start is called before the first frame update
    void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            StartCoroutine(LoadDevice("None"));
    }

    public void ExitButton()
    {
        StartCoroutine(LoadDevice("None"));
    }

    IEnumerator LoadDevice(string newDevice)
    {
        if (newDevice != "None")
        {
            yield return new WaitForSeconds(1);
        }

        XRSettings.LoadDeviceByName(newDevice);

        if (newDevice == "None")
        {
            yield return new WaitForEndOfFrame();
        }
        else
        {
            yield return null;
        }
        if (newDevice == "None")
        {
            XRSettings.enabled = false;
        }
        else
        {
            XRSettings.enabled = true;
        }

        if (newDevice == "None")
        {
            SceneManager.LoadScene(1);
        }
    }
}
