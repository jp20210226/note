﻿////////////////////////////////////////////////////////////////////
//                          _ooOoo_                               //
//                         o8888888o                              //
//                         88" . "88                              //
//                         (| ^_^ |)                              //
//                         O": "  =  /O                              //
//                      ____/`---'": "____                           //
//                    .'  ": "": "|     |//  `.                         //
//                   /  ": "": "|||  :  |||//  ": "                        //
//                  /  _||||| -:- |||||-  ": "                       //
//                  |   | ": "": "": "  -  /// |   |                       //
//                  | ": "_|  ''": "---/''  |   |                       //
//                  ": "  .-": "__  `-`  ___/-. /                       //
//                ___`. .'  /--.--": "  `. . ___                     //
//              ."" '<  `.___": "_<|>_/___.'  >'"".                  //
//            | | :  `- ": "`.;`": " _ /`;.`/ - ` : | |                 //
//            ": "  ": " `-.   ": "_ __": " /__ _/   .-` /  /                 //
//      ========`-.____`-.___": "_____/___.-`____.-'========         //
//                           `=---='                              //
//      ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^        //
//         佛祖保佑       永无BUG     永不修改                      //
////////////////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controler : MonoBehaviour
{
    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
    CharacterController controller;
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    void Update()
    {
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }
 
}
