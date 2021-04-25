
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ces : MonoBehaviour
{
    private Quaternion targetRotation;
    float leftSpeed = 22;
    float middleSpeed = 500;
    float middlePressSpeed = 2;

    [SerializeField] private float min_angle_y = -120f;
    [SerializeField] private float max_angle_y = 89f;
    private void Start()
    {
        //transform.position = new Vector3(0.7105441f, 6.023577f, 9.163477f);
        //transform.rotation = Quaternion.Euler(new Vector3(45f, 179.996f, 0));
    }

    private void Update()
    {
        // Vertical 对应键盘上面的上下箭头，当按下上或下箭头时触发
        float Horizontal = Input.GetAxis("Horizontal");
        // Horizontal 对应键盘上面的左右箭头，当按下左或右箭头时触发
        float Vertical = Input.GetAxis("Vertical");

        // Mouse X  鼠标沿着屏幕X移动时触发
        float MouseX = Input.GetAxis("Mouse X");
        // Mouse Y  鼠标沿着屏幕Y移动时触发
        float MouseY = Input.GetAxis("Mouse Y");
        // Mouse ScrollWheel 当鼠标滚动轮滚动时触发
        float gunluner = Input.GetAxis("Mouse ScrollWheel");
        //this.transform.Translate(new Vector3(1,0, 1) * Time.deltaTime*0.1f, Space.Self );
        if (Input.GetMouseButton(0))
        //this.transform.Translate(MouseX,MouseY, gunlun)
        {
            Vector3 angles = transform.rotation.eulerAngles;
            // 欧拉角表示按照坐标顺序旋转，比如angles.x=30，表示按x轴旋转30°，dy改变引起x轴的变化
            angles.x = Mathf.Repeat(angles.x + 180f, 360f) - 180f;
            angles.y += MouseX * leftSpeed;
            angles.x -= MouseY * leftSpeed;
            //if (angles.x < 15)
            //    angles.x = 15;
            angles.x = ClampAngle(angles.x, min_angle_y, max_angle_y);
            //this.transform.Rotate(angles,Time.deltaTime * speed); ;
            targetRotation.eulerAngles = new Vector3(angles.x, angles.y, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * leftSpeed);
        }
        if (Input.GetMouseButton(2))
        //this.transform.Translate(MouseX,MouseY, gunlun)
        {
            this.transform.Translate(-MouseX * middlePressSpeed, -MouseY * middlePressSpeed, 0);
        }
        if (gunluner != 0)
        //this.transform.Translate(MouseX,MouseY, gunlun)
        {
            this.transform.Translate(0, 0, gunluner * middleSpeed * Time.deltaTime);
        }
        Vector3 a = transform.position;
        //if (a.y < 0.5)
        //    a.y = 0.5f;
        transform.position = new Vector3(a.x, Mathf.Lerp(transform.position.y, a.y, 1), a.z);
    }
    float ClampAngle(float angle, float min, float max)
    {
        // 控制旋转角度不超过360
        if (angle < -360f) angle += 360f;
        if (angle > 360f) angle -= 360f;
        return Mathf.Clamp(angle, min, max);
    }
}

