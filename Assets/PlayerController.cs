using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float moveSpeed;
	public float mouseSpeed;
	public RectTransform cursor;

	private float pitch;
	private float yaw;
	public Vector3 screenCenter;

	private void Start()
	{
		screenCenter = new Vector3(Screen.width / 2f, Screen.height / 2f, 0);
	}

	private void Update()
	{
		Vector3 move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Up"), Input.GetAxis("Vertical")) * Time.deltaTime * moveSpeed;
		transform.Translate(move, Space.Self);

		if ((screenCenter - Input.mousePosition).magnitude > 400)
			cursor.position = screenCenter + Input.mousePosition.normalized * 400;

		pitch = -((Screen.height / 2f) - Input.mousePosition.y) * mouseSpeed;
		yaw = -((Screen.width / 2f) - Input.mousePosition.x) * mouseSpeed;
		//transform.eulerAngles = new Vector3(pitch, yaw, 0);
		transform.Rotate(new Vector3(-pitch, yaw, 0));

	}
}
