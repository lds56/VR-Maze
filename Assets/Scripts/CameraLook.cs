using UnityEngine;
using System.Collections;

public class CameraLook : MonoBehaviour {

	public float sensitivity = 1f;

	public float minimumY = -60f;
	public float maximumY = 60f;

	private float rotationY = 0f;
	private float rotationX = 0f;

	void Update() {
		rotationX = transform.localEulerAngles.y + Input.GetAxis ("Mouse X") * sensitivity;

		rotationY += Input.GetAxis ("Mouse Y") * sensitivity;
		rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);

		transform.localEulerAngles = new Vector3 (-rotationY, rotationX, 0);

	}

}
