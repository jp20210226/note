using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Control : MonoBehaviour
{
    private void OnMouseEnter()
    {
        this.gameObject.transform.DOBlendableLocalMoveBy(new Vector3(10, 0, 10), 2);
    }
    //private void  on
}
