using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Animator aa;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            aa.SetBool("PressG", true);
        }
    }

    public void aaaaa()
    {
        Debug.Log("!!");
    }
}
