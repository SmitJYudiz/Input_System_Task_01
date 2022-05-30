using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerBehaviour : MonoBehaviour
{
    //public Scene startScene;
 
    public void LoadStartScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}
