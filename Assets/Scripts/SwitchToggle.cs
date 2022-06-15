using UnityEngine ;
using UnityEngine.UI ;


public class SwitchToggle : MonoBehaviour {
   
   [SerializeField] RectTransform uiHandleRectTransform ;
   [SerializeField] Color backgroundActiveColor ;
   [SerializeField] Color handleActiveColor ;

   Image backgroundImage, handleImage ;

   Color backgroundDefaultColor, handleDefaultColor ;

   Toggle toggle ;

   Vector2 handlePosition ;

   void Awake ( ) {
      toggle = GetComponent <Toggle> ( ) ;

      handlePosition = uiHandleRectTransform.anchoredPosition ;

      backgroundImage = uiHandleRectTransform.parent.GetComponent <Image> ( ) ;
      handleImage = uiHandleRectTransform.GetComponent <Image> ( ) ;

      backgroundDefaultColor = backgroundImage.color ;
      handleDefaultColor = handleImage.color ;

      toggle.onValueChanged.AddListener (OnSwitch) ;

      if (PlayerPrefs.GetString("PreferredDevice") == "None")
      {
         PlayerPrefs.SetString("PreferredDevice", "None");
         Debug.Log("Left Side");
         OnSwitch(false);
         toggle.isOn = false;
      }
      else if (PlayerPrefs.GetString("PreferredDevice") == "Cardboard")
      {
         PlayerPrefs.SetString("PreferredDevice", "Cardboard");
         Debug.Log("Right Side");
         OnSwitch(true);
         toggle.isOn = true;
      } 

   }

   public void OnSwitch(bool on)
   {
      uiHandleRectTransform.anchoredPosition = on ? handlePosition * -1 : handlePosition;
   }

   public void ToggleVRMode ()
   {
      if (PlayerPrefs.GetString("PreferredDevice") == "None")
      {
         PlayerPrefs.SetString("PreferredDevice", "Cardboard");
         OnSwitch(true);
         toggle.isOn = true;
         Debug.Log("device : cardboard");
      }
      else
      {
         PlayerPrefs.SetString("PreferredDevice", "None");
         OnSwitch(false);
         toggle.isOn = false;
         Debug.Log("device : none");
      }
   }

   void OnDestroy ( ) {
      toggle.onValueChanged.RemoveListener (OnSwitch) ;
   }
}
