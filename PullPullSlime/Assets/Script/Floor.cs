using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
	private Rigidbody rigid;
	private Vector3 defaultPos;

	void Start()
	{
		rigid = GetComponent<Rigidbody>();
		defaultPos = transform.position;
	}

	void FixedUpdate()
	{
		rigid.MovePosition(new Vector3(defaultPos.x, defaultPos.y + Mathf.PingPong(Time.time, 3), defaultPos.z));
	}
}