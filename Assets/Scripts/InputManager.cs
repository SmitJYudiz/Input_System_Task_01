using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InputManager : MonoBehaviour, IPointerDownHandler, IPointerUpHandler,IDragHandler
{
    bool gameResume;
    Canvas canvas;
    private void Awake()
    {
     canvas=   gameObject.AddComponent<Canvas>();
        gameObject.AddComponent<GraphicRaycaster>();


    }

    private void Update()
    {      
       // thisTime = float.Parse(thisTimerTxt.text);
        if(MainScreenBehaviour.Instance.timer< 0.2f)
        {
            gameResume = false;
        }
        else
        {
            gameResume = true;
        }
    }

   

    public void OnDrag(PointerEventData eventData)
    {
        if(Time.timeScale ==1)
        {
           // Debug.Log("Drag executed");
            transform.position = eventData.position;
            //transform.gameObject.GetComponent<Image>().sort
        }      
    }

  /*  public void OnMouseDown(BaseEventData eventData)
    {
        Debug.Log("OnMouseDown executed");
    }
    public void OnMouseDrag(BaseEventData eventData)
    {
        Debug.Log("on mouse drag executed");
        //eventData = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //  eventData.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }*/

    public void OnPointerDown(PointerEventData eventData)
    {
        canvas.overrideSorting = true;
        canvas.sortingOrder = 5;
    //    gameObject.layer = 6;
        //Debug.Log("on pointer down executed");       
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //Debug.Log("On pointer up executed");        
        canvas.sortingOrder = 1;
    }

    public void SetResumeGameBool(bool resumeValue)
    {
        gameResume = resumeValue;
        Debug.Log("now value of gameResume is: " + gameResume);
    }
}
