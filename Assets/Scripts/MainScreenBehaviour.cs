using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//Bugs:
//pause and resume buttons change the gameplay w.r.t adding score, but they do not stop the functionality of OnDrag.
//above bug is solved now.


public  class MainScreenBehaviour : MonoBehaviour
{
    //here we will take three lists, each list contaoning specific category item
    //or in another way take 15 objects and make a list of it...

    public static MainScreenBehaviour Instance;

    public float timer;
    
    public Text timerText;


    bool gameOver = false;
    bool gameOverChangedOnce = false;

    public GameObject inputManager;

    public Text totalScoreText;
    public int totalScore;
 

    public Text dustbinItemCountText;
    public int dustbinItemCount;

    public Text finalScoreTxt;
 
    public Canvas mainScreen;
    public Canvas finalScreen;
    public Canvas soundSettingCanvas;

    public AudioSource bgMusic;
    void Start()
    {
          //120 seconds of time.
             // InstantiateObjectsOnScreenBehaviour.Instance.PlaceItemsOnScreen();
        totalScore = 0;       
        //dustbinItemCount = 0;
        //dustbinItemCountText.text = dustbinItemCount.ToString();
       /* if(bgMusic !=null)
        {
            bgMusic.Play();
        }*/
    }

    private void Awake()
    {       
        timer = 25f;
        Instance = this;

        /*mainScreen.GetComponent<Canvas>().enabled = true;
        finalScreen.GetComponent<Canvas>().enabled = false;
        soundSettingCanvas.GetComponent<Canvas>().enabled = false;*/
    }

    // Update is called once per frame
    void Update()
    {        
        if(timer > 0)
        {
            timerText.text = timer.ToString("F3");
            timer-=Time.deltaTime;
        }
        if(timer< 20)
        {
            if(Mathf.Floor(timer)%2==0)
            {
                timerText.color = Color.red;            
            }
            else
            {
                timerText.color = Color.white;           
            }
            
        }
        
        if(timer<0)
        {
            finalScoreTxt.text = totalScore.ToString() ;
            mainScreen.gameObject.SetActive(false);
            finalScreen.gameObject.SetActive(true);

        }

        if (gameOver && gameOverChangedOnce == false)
        {
            Time.timeScale = 0;      //this will pause the gameplay.
            Debug.Log("GameOver");
           timerText.text = 0000.ToString("F4");
            gameOverChangedOnce = true;
        }      
    }

    public void IncreaseTotalScore(int score)
    {
        totalScore += score;
        totalScoreText.text = totalScore.ToString();
    }
    public void DecreaseTotalScore(int score)
    {
        totalScore -= score;
        totalScoreText.text = totalScore.ToString();
    }

   public void PauseGame()
    {   
       // inputManager.GetComponent<InputManager>().SetResumeGameBool(false);
        Time.timeScale = 0;
        bgMusic.Pause();
    }

    public void ResumeGame()
    {  
        inputManager.GetComponent<InputManager>().SetResumeGameBool(true);
        Time.timeScale = 1;
        bgMusic.Play();
    }

    public void IncDecDustbinCount()
    {
        dustbinItemCount ++;
        dustbinItemCountText.text = dustbinItemCount.ToString();
    }

    public void GoToSoundSettings()
    {
        PauseGame();
       
        soundSettingCanvas.gameObject.SetActive(true);    
        mainScreen.gameObject.SetActive(false);
        finalScreen.gameObject.SetActive(false);
/*
        soundSettingCanvas.GetComponent<Canvas>().enabled = true;
        mainScreen.GetComponent<Canvas>().enabled = false;
        finalScreen.GetComponent<Canvas>().enabled = false;
      */


    }
}
