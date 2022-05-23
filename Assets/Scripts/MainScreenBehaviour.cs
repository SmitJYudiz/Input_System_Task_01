using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//Bugs:
//pause and resume buttons change the gameplay w.r.t adding score, but they do not stop the functionality of OnDrag.


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
    // Start is called before the first frame update

    public Text dustbinItemCountText;
    public int dustbinItemCount;

    public Text finalScoreTxt;
    /*  public Text finalFruitTxt;
      public Text AccessoryText;
      public Text TrekkingText;*/

    public Canvas mainScreen;
    public Canvas finalScreen;

    void Start()
    {
          //120 seconds of time.
             // InstantiateObjectsOnScreenBehaviour.Instance.PlaceItemsOnScreen();
        totalScore = 0;       
        //dustbinItemCount = 0;
        //dustbinItemCountText.text = dustbinItemCount.ToString();
    }

    private void Awake()
    {       
        timer = 25f;
        Instance = this;
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
    }

    public void ResumeGame()
    {  
        inputManager.GetComponent<InputManager>().SetResumeGameBool(true);
        Time.timeScale = 1;
    }

    public void IncDecDustbinCount()
    {
        dustbinItemCount ++;
        dustbinItemCountText.text = dustbinItemCount.ToString();
    }
}
