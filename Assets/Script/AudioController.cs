using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class AudioController : MonoBehaviour
{
    public static AudioController aud;
 
    public AudioSource musicAud;
    
    public AudioSource soundAud;
    public AudioClip win;
    public AudioClip rightAnswer;
    public AudioClip wrongAnswer;
    private void Awake()
    {
        makeSingleton();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void makeSingleton()
    {
        if (aud == null)
            aud = this;
        else
            Destroy(gameObject);
    }
    void PlaySound(AudioClip sound)
    {
        if(soundAud && sound)
        {
            soundAud.PlayOneShot(sound);
        }
    }
    public void PlayCorrectSound()
    {
        PlaySound(rightAnswer);
    }
    public void PlayLoseSound()
    {
        PlaySound(wrongAnswer);
    }
    public void PlayWinSound()
    {
        PlaySound(win);
    }
}
