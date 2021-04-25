using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class click : MonoBehaviour,IPointerEnterHandler
{
    public  void  OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("ca");
    }

}
