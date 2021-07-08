using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour
{
    public Text answerText;
    public Button button;
    public void setAnswerText(string answer){
        if (answerText)
        {
            answerText.text = answer;
        }
    }
}
