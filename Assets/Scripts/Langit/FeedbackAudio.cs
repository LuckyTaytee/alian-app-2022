using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedbackAudio : MonoBehaviour
{
    public AudioSource feedbackAudio;

    // Start is called before the first frame update
    void Start()
    {
        feedbackAudio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
