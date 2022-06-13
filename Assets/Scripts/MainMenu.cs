using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class MainMenu : MonoBehaviour
{
    public string preferredDevice = "None";

    void Awake()
    {
        if (PlayerPrefs.GetInt("ToggleSelected") == 0)
        {
            preferredDevice = "None";
            Debug.Log("ToggleSelected = 0 + device : none");
        }
        else if (PlayerPrefs.GetInt("ToggleSelected") == 1)
        {
            preferredDevice = "cardboard";
            Debug.Log("ToggleSelected = 1 + device : cardboard");
        } 
        else
        {
            PlayerPrefs.SetInt("ToggleSelected", 0);
            preferredDevice = "None";
            Debug.Log("ToggleSelected = 0 + device : none");
        }
    }
    
    public void ToggleVRMode ()
    {
        if (PlayerPrefs.GetInt("ToggleSelected") == 0)
        {
            PlayerPrefs.SetInt("ToggleSelected", 1);
            preferredDevice = "cardboard";
            Debug.Log("ToggleSelected = 1 + device : cardboard");
        }
        else
        {
            PlayerPrefs.SetInt("ToggleSelected", 0);
            preferredDevice = "None";
            Debug.Log("ToggleSelected = 0 + device : none");
        }
    }

    public void VRMode ()
    {
        StartCoroutine(LoadDevice(preferredDevice));
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
            Debug.Log("Device = None");
        }
        else
        {
            XRSettings.enabled = true;
            Debug.Log("Device = cardboard");
        }

        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    public void QuitGame ()
    {
        Application.Quit();
    }
}
