using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class MainMenu : MonoBehaviour
{
    void Awake()
    {
        if (!PlayerPrefs.HasKey("PreferredDevice"))
        {
            PlayerPrefs.SetString("PreferredDevice", "None");
            Debug.Log("new playerprefs created");
        }
        else
        {
            if (PlayerPrefs.GetString("PreferredDevice") == "None")
            {
                Debug.Log("device : none");
            }
            else
            {
                Debug.Log("device : cardboard");
            }
        }
    }

    public void VRMode ()
    {
        StartCoroutine(LoadDevice(PlayerPrefs.GetString("PreferredDevice")));
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
            Debug.Log("Device = Cardboard");
        }

        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
