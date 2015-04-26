using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	//public float jumpSpeed;
	public float gravity;
	//public float sensitivity;
	private GameObject head;
	private GameObject player;
	private Vector3 moveDirection = Vector3.zero;
	private bool moveStatus = false;
	private CharacterController controller;
	//private Rigidbody rb;
	//private float prevMoveY = 0;
	void Start(){
		//rb = GetComponent<Rigidbody> ();
		head=GameObject.Find("Head");
		player = GameObject.Find ("PlayerArmature");
		controller = GetComponent<CharacterController>();
	}

	void Update() {
	/*
		if (Input.GetMouseButtonDown (0)) {
			Debug.Log("Mouse down");
			moveStatus = !moveStatus;
		}
*/
		float curSpeed = moveStatus? speed : 0;
		moveDirection = head.transform.forward * 0.01f * curSpeed;
		moveDirection.y -= gravity;
		controller.Move (moveDirection);
		player.transform.eulerAngles = new Vector3 (270, head.transform.eulerAngles.y, 0);
		//transform.eulerAngles=new Vector3(head.transform.eulerAngles.x,head.transform.eulerAngles.y,head.transform.eulerAngles.z);
		//Debug.Log("Forward: " + head.transform.forward);

	}
	/*
	public void SetGazedAt(bool gazedAt) {
		GetComponent<Renderer>().material.color = gazedAt ? Color.green : Color.red;
		Debug.Log ("gaze!");
	}

*/
	
	public void moveOrStop()
	{
		moveStatus = !moveStatus;
		//Debug.Log ("click!");
	}

	//void OnTriggerEnter(Collider other) {
		//Debug.Log ("Collide");
	//	moveStatus = false;
	//}
}
