using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
   
    public List<Toggle> toggles;

    public Slider volumeSlider;
  
    void Start()
    {
        //toggles = GetComponent<List<Toggle>>(); 
        foreach(Toggle toggle in toggles)
        {
            toggle.onValueChanged.AddListener(OnValueChanged);
        }
    }

    
    public bool selectedOptionForSound; //true means sound 0n, false means off.
    public void OnValueChanged(bool value)
    {
    
        for(int i=0; i<toggles.Count; i++)
        {
            if(toggles[i].isOn)
            {
                if(i==0)
                {
                    selectedOptionForSound = true; 
                }
                else
                {
                    selectedOptionForSound = false;
                   //MainScreenBehaviour.Instance.bgMusic.playOnAwake = false;
                }
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (selectedOptionForSound)
        {
            MainScreenBehaviour.Instance.bgMusic.volume = volumeSlider.value;
            //MainScreenBehaviour.Instance.bgMusic.volume = 1;
        }
        else
        {
            MainScreenBehaviour.Instance.bgMusic.volume = 0;
        }

    //    MainScreenBehaviour.Instance.bgMusic.volume = volumeSlider.value;
    }

    

    public void BackToMainScreen()
    {
        MainScreenBehaviour.Instance.mainScreen.gameObject.SetActive(true);
        //MainScreenBehaviour.Instance.mainScreen.GetComponent<Canvas>().enabled = true;

        MainScreenBehaviour.Instance.soundSettingCanvas.gameObject.SetActive(false);
        //MainScreenBehaviour.Instance.soundSettingCanvas.GetComponent<Canvas>().enabled = false;
        MainScreenBehaviour.Instance.ResumeGame();
    }  
}
