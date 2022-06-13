using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeCycle3Minigame : MonoBehaviour
{
    public static LifeCycle3Minigame instance;
    public float timer;
    public float timeToClicker;
    public float progress = 0f;
    public Image progressBarImage;

    // Start is called before the first frame update
    void Start()
    {
        ProgressBar.instance.minigameObject = gameObject;
        progressBarImage = ProgressBar.instance.transform.Find("Image").Find("Image").GetComponent<Image>();
        progressBarImage.fillAmount = Mathf.Clamp(progress / 10, 0, 1f);
        RotateCanvasBehavior.instance.minigameObject = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (ARSessionScriptPembelajaranAR.instance.panelInformasi.gameObject.activeSelf == false) 
        {
            progress += Time.deltaTime;
            progressBarImage.fillAmount = Mathf.Clamp(progress / 10, 0, 1f);
            if (progress >= 10f)
            {
                ARSessionScriptPembelajaranAR.instance.LifeCyclePhase4();
            }
        }
       
    }
}
