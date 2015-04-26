using UnityEngine;
using System.Collections;

public class JJExplode : MonoBehaviour {
	public ParticleSystem exp;
//	void Start() {
//		Explode ();
//	}
	
//	void OnTriggerEnter(Collider other) 
//	{
//		
//		Debug.Log ("cl");
//		if (other.gameObject.tag == "PlayerTag")
//		{
//			Debug.Log ("collision");
//			Explode();
//			//			other.gameObject.SetActive (false);
//			//			gameObject.SetActive (false);
//			Destroy (gameObject, 0.8f);
//		}
//	}
		void OnTriggerEnter(Collider other) {
//			shouldStop = true;
			Debug.Log ("cl");

			if (other.gameObject.tag == "PlayerTag")
			{
				Debug.Log ("collision");
				Explode();
				//			other.gameObject.SetActive (false);
				//			gameObject.SetActive (false);
				Destroy (gameObject, 2f);
			}
		}
	void Explode() {
		exp.Play();
	}
}
