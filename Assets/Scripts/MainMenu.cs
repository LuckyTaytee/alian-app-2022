using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class MainMenu : MonoBehaviour
{
    public string preferredDevice = "None";

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
        }
        else
        {
            XRSettings.enabled = true;
        }

        //if (newDevice != "None")
        //{
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //}
    }

    public void ToggleVRMode ()
    {
        if(preferredDevice == "None")
        {
            preferredDevice = "cardboard";
        }
        else
        {
            preferredDevice = "None";
        }
    }



    public void QuitGame ()
    {
        Application.Quit();
    }
}
