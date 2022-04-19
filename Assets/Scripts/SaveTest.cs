using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveTest : MonoBehaviour
{
    #if !UNITY_EDITOR
    AndroidJavaObject currentActivity;
    #endif

    void Start()
    {
        #if !UNITY_EDITOR
        //currentActivity androidjavaobject must be assigned for toasts to access currentactivity;
        AndroidJavaClass UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        currentActivity = UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        #endif
    }

    void Update()
    {
        var saveManager = SaveManager.Instance;
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log(saveManager.State.Count);
            Debug.Log(saveManager.State.butterfly2);
        }       

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            saveManager.State.Count += 1;
            Debug.Log("Added one to the count .. " + saveManager.State.Count);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            saveManager.Save();
            Debug.Log("Saving state on .. " + saveManager.State.LastSaveTime);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SaveManager.Instance.Load();
            Debug.Log("Loaded state on .. " + saveManager.State.LastSaveTime);
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            saveManager.State.butterfly2 = true;
            Debug.Log("Butterfly Obtained? " + saveManager.State.butterfly2);
        }

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            saveManager.State.butterfly2 = false;
            Debug.Log("Butterfly Obtained? " + saveManager.State.butterfly2);
        }
    }

    public void SendToastyToast(string message)
        {
            #if !UNITY_EDITOR
            AndroidJavaObject context = currentActivity.Call<AndroidJavaObject>("getApplicationContext");
            AndroidJavaClass Toast = new AndroidJavaClass("android.widget.Toast");
            AndroidJavaObject javaString = new AndroidJavaObject("java.lang.String", message);
            AndroidJavaObject toast = Toast.CallStatic<AndroidJavaObject>("makeText", context, javaString, Toast.GetStatic<int>("LENGTH_LONG"));
            toast.Call("show");
            #endif
        }

    public void OnTriggerEvent2(Collider collider)
    {
        Destroy(collider.gameObject);
        SaveManager.Instance.State.butterfly2 = true;
        Debug.Log("Butterfly2 Obtained? " + SaveManager.Instance.State.butterfly2);
        // SendToastyToast("Butterfly2 Collected");
    }

        public void OnTriggerEvent3(Collider collider)
    {
        Destroy(collider.gameObject);
        SaveManager.Instance.State.butterfly3 = true;
        Debug.Log("Butterfly3 Obtained? " + SaveManager.Instance.State.butterfly3);
        // SendToastyToast("Butterfly3 Collected");
    }
}
