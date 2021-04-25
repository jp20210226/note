using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DebugModeHelper : MonoBehaviour, IPointerDownHandler
{
    GameObject State;
    bool _isClick;
    private void Awake()
    {
        State = Resources.Load("Debug/ShowBtnState") as GameObject;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        _isClick = !_isClick;
        if (_isClick)  Instantiate(State, transform);
        else
        {
            GameObject State = transform.Find("ShowBtnState(Clone)").gameObject;
            if (!State) return;
            Destroy(State);
        }
    }

}
