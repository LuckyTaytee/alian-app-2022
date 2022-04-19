using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace VrAlian
{
    public class CollectItem : MonoBehaviour
    {
        //[SerializeField] private Image overheadImage = null;
        [SerializeField] private Item itemThatGetsPickedUp = null;
        [SerializeField] private int numberPickedUp = 1;

        //AndroidJavaObject currentActivity;

        public void OnTriggerEvent(Collider collision)
        {
            print("Collecting");
            AddToInventoryAndDestroyThis(collision.gameObject);

            //SendToastyToast("Butterfly Collected");
        }

        public void Start()
        {
            //currentActivity androidjavaobject must be assigned for toasts to access currentactivity;
            //AndroidJavaClass UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            //currentActivity = UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        }

        private void AddToInventoryAndDestroyThis(GameObject playerObject) 
        {
            playerObject.GetComponent<Inventory>().AddToInventory(itemThatGetsPickedUp, numberPickedUp);
            Destroy(gameObject);
        }

        public void SendToastyToast(string message)
        {
            /*
            AndroidJavaObject context = currentActivity.Call<AndroidJavaObject>("getApplicationContext");
            AndroidJavaClass Toast = new AndroidJavaClass("android.widget.Toast");
            AndroidJavaObject javaString = new AndroidJavaObject("java.lang.String", message);
            AndroidJavaObject toast = Toast.CallStatic<AndroidJavaObject>("makeText", context, javaString, Toast.GetStatic<int>("LENGTH_LONG"));
            toast.Call("show");
            */
        }
    }


}