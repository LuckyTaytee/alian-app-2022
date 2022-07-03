using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerScript : MonoBehaviour
{
    bool isFeedback = false;
    public bool isCorrect = false;
    public QuizManager quizManager;
    public GameObject feed_benar, feed_salah;
    public Button button_A, button_B, button_C, button_D;

    public void Answer()
    {
        //if (isFeedback != true)
        //StartCoroutine(CheckAnswer());
        ToggleButton(false);
        Debug.Log("Button not interactabel");

        if(isCorrect)
        {
            feed_benar.SetActive (false);
            feed_benar.SetActive (true);
            Debug.Log("Correct Answer");
            Invoke("NextCorrect", 2.0f);
        }
        else
        {
            feed_salah.SetActive (false);
            feed_salah.SetActive (true);
            Debug.Log("Wrong Answer");
            Invoke("NextWrong", 2.0f);
        }
    }

    void NextCorrect()
    {
        quizManager.correct();
        ToggleButton(true);
    }

    void NextWrong()
    {
        quizManager.wrong();
        ToggleButton(true);
    }

    public void ToggleButton(bool toggle)
    {
        button_A.interactable = toggle;
        button_B.interactable = toggle;
        button_C.interactable = toggle;
        button_D.interactable = toggle; 
    }
}
