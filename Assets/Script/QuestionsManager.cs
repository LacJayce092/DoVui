using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class QuestionsManager : MonoBehaviour
{
    public static QuestionsManager ins;
    public QuestionsData[] questions;
    private List<QuestionsData> m_question;
    private QuestionsData curQuestion;

    public QuestionsData CurQuestion { get => curQuestion; set => curQuestion = value; }
    public List<QuestionsData> Question { get => m_question; set => m_question = value; }

    public void Awake()
    {
        m_question = questions.ToList();
        makeSingleton();
        
    }
    int easy = 49;
    int normal = 94;
    int hard = 139;
    public QuestionsData getRandomQuestion()
    {
        
        if (m_question != null && m_question.Count > 0)
        {
            if (GameController.stt <= 5)           {
                        
                int rand = Random.Range(0, easy);             
                curQuestion = m_question[rand];               
                m_question.RemoveAt(rand);
                easy--;


            }
            if (GameController.stt > 5 && GameController.stt <=10)
            {
               
                int norRand = Random.Range(44, normal);
                curQuestion = m_question[norRand];             
                m_question.RemoveAt(norRand);
                normal--;

            }
            if (GameController.stt > 10 && GameController.stt <= 15)
            {
               
                int hardRand = Random.Range(90, hard);
                curQuestion = m_question[hardRand];
                m_question.RemoveAt(hardRand);
                hard--;

            }

        }
        return curQuestion;
    }
    public void makeSingleton() {
        if (ins == null)
            ins = this;
        else
            Destroy(gameObject);
    }

}
