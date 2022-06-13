using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifecycleMinigame1 : MonoBehaviour
{
    public static LifecycleMinigame1 instance;
    private Canvas progressBarCanvas; 
    public float progress = 0f;
    public float progressSubstraction;
    public float progressAddition; 
    public float secondsToSubstractProgress;
    public float timer = 0f;
    public Image progressBarImage;
    private static float maxProgress = 100f;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        ProgressBar.instance.minigameObject = gameObject;
        RotateCanvasBehavior.instance.minigameObject = gameObject;
        progressBarImage = ProgressBar.instance.transform.Find("Image").Find("Image").GetComponent<Image>();

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= secondsToSubstractProgress)
        {
            timer -= secondsToSubstractProgress;
            if (progress - progressSubstraction < 0)
            {
                progress = 0;
            }
            else
            {
                progress -= progressSubstraction;
            }
        }
        if (progress >= maxProgress)
        {
            NextPhase();
        }
        ProgressBarAdjust();
    }

    public void EggClicked()
    {
        progress += progressAddition;
        
    }

    public void NextPhase() {
        Debug.Log("NextPhase");
        ARSessionScriptPembelajaranAR.instance.LifeCyclePhase2();
    }

    public void ProgressBarAdjust(){
        progressBarImage.fillAmount = Mathf.Clamp(progress / maxProgress, 0, 1f);
    }
}
