using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public float speed;
	//public float jumpSpeed;
	public float gravity;
	//public float sensitivity;
	private GameObject head;
	private Vector3 moveDirection = Vector3.zero;
	private bool moveStatus = false;
	//private float prevMoveY = 0;
	void Start(){
		head=GameObject.Find("Head");
	}

	void Update() {

		CharacterController controller = GetComponent<CharacterController>();

		if (Input.GetMouseButtonDown (0)) {
			Debug.Log("Mouse down");
			moveStatus = !moveStatus;
		}

		float curSpeed = moveStatus? speed : 0;
		moveDirection = head.transform.forward * 0.01f * curSpeed;
		moveDirection.y -= gravity;
		controller.Move (moveDirection);

		Debug.Log("Forward: " + head.transform.forward);

	}

	//void OnTriggerEnter(Collider other) {
		//Debug.Log ("Collide");
	//	moveStatus = false;
	//}
}
