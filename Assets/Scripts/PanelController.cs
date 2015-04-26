using UnityEngine;
using System.Collections;

public class PanelController : MonoBehaviour {
	private GameObject wall;
	private GameObject light;
	private GameObject ground;
	void Start()
	{
		light= GameObject.Find ("Point light");
		wall = GameObject.Find ("Wall");
		ground=GameObject.Find ("GROUND");
	}

	public void Replay()
	{
		DontDestroyOnLoad (wall);
		DontDestroyOnLoad (ground);
		DontDestroyOnLoad (light);
		Application.LoadLevel (Application.loadedLevel);
	}
}