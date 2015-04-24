using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public float speed;
	public float jumpSpeed;
	public float gravity;
	public float sensitivity;

	private Vector3 moveDirection = Vector3.zero;
	private bool moveStatus = false;
	//private float prevMoveY = 0;

	void Update() {

		CharacterController controller = GetComponent<CharacterController>();

		if (Input.GetMouseButtonDown (0)) {
			Debug.Log("Mouse down");
			moveStatus = !moveStatus;
		}

		float curSpeed = moveStatus? speed : 0;
		controller.Move (Camera.main.transform.forward * 0.01f * curSpeed);

		Debug.Log("Forward: " + Camera.main.transform.forward);

	}


}
