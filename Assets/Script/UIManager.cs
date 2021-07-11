using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager ins;

    public Text timeText;
    public Text questionsText;
    public Text sttText;
    public Dialog dialog;
    public AnswerButton[] answerButtons;
    public Button pausebutt;
    public PauseMenu pauseMenuUI;
    public Text scoreText;

    public void Awake()
    {
        makeSingleton();
    }
    public void setScoreText(string contents)
    {
        if (scoreText)
        {
            scoreText.text = contents;
        }
    }
    public void setTimeText(string contents)
    {
        if (timeText)
            timeText.text = contents;
    }
    public void setQuestionsText(string contents)
    {
        if (questionsText)
        {
            questionsText.text = contents;
        }
    }
    public void setSttText(string contents)
    {
        if (sttText)
        {
            sttText.text = contents;
        }
    }

    public void makeSingleton()
    {
        if (ins == null)
        {
            ins = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void ShuffleAnswers()
    {
        if(answerButtons != null && answerButtons.Length > 0)
        {
            for (int i = 0; i < answerButtons.Length; i++)
            {
                  if(answerButtons[i] != null)
                { 
                    answerButtons[i].tag = "Untagged";
                }
            }
            int rand = Random.Range(0, answerButtons.Length);
            if(answerButtons[rand] != null)
            {
                answerButtons[rand].tag = "RightAnswer";
            }
        }
    }


}
