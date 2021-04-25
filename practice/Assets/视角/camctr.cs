using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camctr : MonoBehaviour
{
	/// <summary>
	/// 跟随目标
	/// </summary>
	public Transform Target;

	/// <summary>
	/// Distance between target and me
	/// </summary>
	public float Dis = 5;

	/// <summary>
	/// 最大转动速度
	/// </summary>
	public int MaxRotSpeed = 100;

	/// <summary>
	/// Y轴转动角度范围
	/// </summary>
	public float YMaxAngel = 30f;
	public float YMinAngel = -60f;

	/// <summary>
	/// 转动阻尼
	/// </summary>
	public int RotDamping = 5;

	/// <summary>
	/// Y轴跟随阻尼
	/// </summary>
	public int YFollowDamping = 3;

	/// <summary>
	/// 默认绕X旋转角度
	/// </summary>
	private int DefaultX = -8;

	/// <summary>
	/// 高度偏移
	/// </summary>
	public Vector3 OffHeight = new Vector3(0, 1, 0);

	/// <summary>
	/// 注视目标点
	/// </summary>
	public Vector3 TargetPos
	{
		get
		{
			return Target.position + OffHeight;
		}
	}

	/// <summary>
	/// 角速度
	/// </summary>
	private float XRotSpeed;
	private float YRotSpeed;

	/// <summary>
	/// 转动角度
	/// </summary>
	private float xRot;
	private float yRot;

	private Transform myTrans;

	public void Start()
	{
		myTrans = transform;

		//Camera初始位置在target的后方
		Vector3 originDir = -Target.forward;
		Quaternion qua = Quaternion.LookRotation(originDir);
		yRot = qua.eulerAngles.y;
		xRot = DefaultX;
	}

	private Quaternion qua;
	private Vector3 newPos;
	public void Update()
	{
		CameraMove();
	}

	private void CameraMove()
	{
		//获取旋转速度
		XRotSpeed = Mathf.Lerp(XRotSpeed, Input.GetAxis("Mouse Y") * MaxRotSpeed, 1f / RotDamping);
		YRotSpeed = Mathf.Lerp(YRotSpeed, Input.GetAxis("Mouse X") * MaxRotSpeed, 1f / RotDamping);

		//计算旋转角度
		xRot += XRotSpeed * Time.deltaTime;
		yRot += YRotSpeed * Time.deltaTime;

		//限制范围
		xRot = Mathf.Clamp(xRot, YMinAngel, YMaxAngel);
		yRot = Mathf.Repeat(yRot, 360);

		qua = Quaternion.Euler(new Vector3(xRot, yRot, 0));

		//向量Vector3.forward * Dis旋转qua后，+ TargetPos，即为最终Camera的位置
		newPos = TargetPos + qua * Vector3.forward * Dis;

		//Y轴延迟跟随
		newPos.y = Mathf.Lerp(myTrans.position.y, newPos.y, 1f / YFollowDamping);

		//更新Camera位置并看向目标
		myTrans.position = newPos;
		myTrans.LookAt(TargetPos);
	}

	public void SetTarget(Transform tgt)
	{
		Target = tgt;
	}
}
