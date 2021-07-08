using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[System.Serializable]
public class GameController : MonoBehaviour
{
    private int rightAnswerNumber =  0;
    public float timeCount;
    public float curTime;
    public static int stt = 1;

  

    private void Awake()
    {
        curTime = timeCount;
    }
    void Start()
    {
        UIManager.ins.setTimeText("" + timeCount);
        createQuestions();
        StartCoroutine(timeCountingDown());
      

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void createQuestions()
    {      
        QuestionsData q = QuestionsManager.ins.getRandomQuestion();
        
        if(q != null)
        {
            UIManager.ins.setSttText("Câu: " + stt);
            stt++;
            UIManager.ins.setQuestionsText(q.question);     
            string[] wrongAnswer = new string[] { q.answerA, q.answerB, q.answerC };
            UIManager.ins.ShuffleAnswers();
            var temp = UIManager.ins.answerButtons;
            if(temp != null && temp.Length > 0)
            {
                int wrongAnswerCount = 0;
                for (int i = 0; i < temp.Length; i++)
                {
                    int answerID = i;
                    if (string.Compare(temp[i].tag , "RightAnswer") == 0)
                    {
                        temp[i].setAnswerText(q.rightAnswer);
                    }else
                    {
                        temp[i].setAnswerText(wrongAnswer[wrongAnswerCount]);
                        wrongAnswerCount++;
                    }
                    temp[answerID].button.onClick.RemoveAllListeners(); 
                    temp[answerID].button.onClick.AddListener(() => checkRightAnswerEvent(temp[answerID]));
                }

            }
        }

    }
    public void checkRightAnswerEvent(AnswerButton answerButton)
    {
        if (answerButton.CompareTag("RightAnswer"))
        {
            curTime = timeCount;
            UIManager.ins.setTimeText("" + curTime);
            rightAnswerNumber++;
            if (rightAnswerNumber == 15)
            {
                UIManager.ins.dialog.setDialogcontent("Bạn đã chiến thắng !!");
                UIManager.ins.dialog.showDialog(true);
                stt = 1;
                StopAllCoroutines();
            }
            else
            {
                createQuestions();
            }
        }
        else
        {
            UIManager.ins.dialog.setDialogcontent("Bạn đã chọn sai !!");
            UIManager.ins.dialog.showDialog(true);
            rightAnswerNumber = 0;
            stt = 1;
            StopAllCoroutines();
        }
    }

    IEnumerator timeCountingDown()
    {
        yield return new WaitForSeconds(1);
            if(curTime >= 0)
        {
            StartCoroutine(timeCountingDown());
            UIManager.ins.setTimeText("" + curTime);
            curTime--;
        }else
        {
            UIManager.ins.dialog.setDialogcontent("Hết giờ !!");
            UIManager.ins.dialog.showDialog(true);
            rightAnswerNumber = 0;
            stt = 1;
            StopAllCoroutines();
        }
           
       
    }
    public void replay()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void exitToMenu()
    {
        Application.Quit();

    }
   
}
