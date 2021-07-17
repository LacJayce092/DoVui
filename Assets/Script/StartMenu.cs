using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
[System.Serializable]
public class StartMenu : MonoBehaviour
{
   
    public  static StartMenu menu;
   

   private void Awake()
    {
      makeSingleton();
    }
    private void Start()
    {
      
    }
   
    public void showStartMenu(bool isShow)
    {
        gameObject.SetActive(isShow);

    }
 
  
    
    public void Quit()
    {
        Application.Quit();

    }
    
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
       
    }
   void makeSingleton()
    {
        if (menu == null)
            menu = this;
        else
            Destroy(gameObject);
    }

   
}
