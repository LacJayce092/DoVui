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
    public int score = 0;
    public int cur_Score;
  
 
   
   
     
  

    private void Awake()
    {
        curTime = timeCount;
    }
    void Start()
    {
        stt = 1;
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
        UIManager.ins.setScoreText("" + score);
        
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
            score += stt * 10 * (int)curTime;
            cur_Score = score;
            AudioController.aud.PlayCorrectSound();
            curTime = timeCount;
            UIManager.ins.setTimeText("" + curTime);
            rightAnswerNumber++;
            if (rightAnswerNumber == 15)
            {
                AudioController.aud.PlayWinSound();
                UIManager.ins.dialog.setDialogcontent("Bạn đã chiến thắng. Điểm số: " + cur_Score);
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
            AudioController.aud.PlayLoseSound();
            UIManager.ins.dialog.setDialogcontent("Bạn đã chọn sai. Điểm số: " + cur_Score);
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
            AudioController.aud.PlayLoseSound();
            UIManager.ins.dialog.setDialogcontent("Hết giờ. Điểm số: " + cur_Score);
            UIManager.ins.dialog.showDialog(true);
            rightAnswerNumber = 0;
            stt = 1;
            StopAllCoroutines();
        }
           
       
    }
    
    public void replay()
    {
        SceneManager.LoadScene("SampleScene");
        stt = 1;
    }
   
  
    public void pause()
    {
        UIManager.ins.pauseMenuUI.showPauseMenu(true);
        Time.timeScale = 0f;
    }
    public void resume()
    {
        UIManager.ins.pauseMenuUI.showPauseMenu(false);
        Time.timeScale = 1f;
    }
    public void exitToMenu()
    {

        SceneManager.LoadScene("StartMenu");
        UIManager.ins.pauseMenuUI.showPauseMenu(false);
        Time.timeScale = 1f;
    }
 

}
