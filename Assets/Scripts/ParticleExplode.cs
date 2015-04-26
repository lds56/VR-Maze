using UnityEngine;
using System.Collections;

public class ParticleExplode : MonoBehaviour {
	public GameObject walls;

	void OnParticleCollision(GameObject other) {
		Rigidbody body = other.GetComponent<Rigidbody>();
		foreach (Rigidbody rb in walls.GetComponentsInChildren<Rigidbody>()) {
			rb.isKinematic = false;
			rb.useGravity = false;
		}
		if (body) {
			Vector3 direction = other.transform.position - transform.position;
			direction = direction.normalized;
			if (body.gameObject.tag != "creeper") {
				//body.isKinematic = false;
				body.AddForce(direction * 5000);
				Debug.Log ("aa");
			}

//			body.AddForce(direction * -500000);
			Debug.Log ("boom!");
		}
	}
}
