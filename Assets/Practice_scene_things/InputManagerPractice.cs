using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManagerPractice : MonoBehaviour
{
    public void OnMouseDown(BaseEventData eventData)
    {
        Debug.Log("OnMouseDown executed");
    }

    public void OnMouseDrag(BaseEventData eventData)
    {
        Debug.Log("OnMouseDrag used");
    }
}
