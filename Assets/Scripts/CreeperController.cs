using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;

public class Pos
{
	public int x, y;
	public int step;
	private int choice = 0;

	public Pos (int x, int y, int step)
	{
		this.x = x;
		this.y = y;
		this.step = step;
	}

	public bool equalTo (Pos other)
	{
		return other.x == this.x && other.y == this.y;
	}

	public Pos addPos (Pos other)
	{
		return new Pos (this.x + other.x, this.y + other.y, this.step + 1);
	}

	public Pos scale(int factor){
		return new Pos (this.x * factor, this.y * factor, this.step);
	}

	public void setChoiceFrom (Pos other, int c)
	{
		if (other.choice == 0)
			this.choice = c;
		else
			this.choice = other.choice;
	}

	public int getChoice ()
	{
		return this.choice;
	}

}

public class CreeperController : MonoBehaviour
{
	
	public int[,] isBricks;
	public float speed;
	public int gravity;
	public GameObject target;

	private int mazeSize = 30;
	private Pos nowPos;
	private readonly int WALL = 1;
	private readonly int BLANK = 0;
	//private readonly string TARGET_OBJ = "Capsule";
	
	private readonly Pos [] moveArray = {
		new Pos (0, 0, 0),
		new Pos (1, 0, 0),
		new Pos (-1, 0, 0),
		new Pos (0, -1, 0),
		new Pos (0, 1, 0)
	};
	
	private CharacterController controller;

	// Use this for initialization
	void Start ()
	{
		isBricks = new int [mazeSize, mazeSize];
		controller = GetComponent<CharacterController>();
		LoadData ("maze");		

	}
	
	// Update is called once per frame
	void Update ()
	{
		nowPos = WorldToLocal (transform.position);
		Debug.Log ("now: " + nowPos.x + ", " + nowPos.y);

		//GameObject target = GameObject.Find (TARGET_OBJ);
		Pos endPos = WorldToLocal (target.transform.position);
		Debug.Log ("target: " + endPos.x + ", " + endPos.y);


		if (!nowPos.equalTo (endPos)) {
			Pos deltaPos = moveArray[FindNextStep (endPos).getChoice()];
			Vector3 moveVector = new Vector3(deltaPos.x, -gravity, deltaPos.y) * speed;
			//moveVector = transform.TransformDirection(moveVector) * speed;
			controller.Move(moveVector);
			//transform.Translate (new Vector3(deltaPos.x, -gravity, deltaPos.y) * speed); //!!!
			Debug.Log ("next: " + transform.position.x + ", " + transform.position.z);
		}
	}

	Pos FindNextStep (Pos endPos)
	{
		bool [,] isVisited = new bool [mazeSize, mazeSize];
		int maxStep = 100;
		Queue<Pos> queue = new Queue<Pos> ();
		Pos resultPos = nowPos;

		int k = 0;

		queue.Enqueue (nowPos);
		isVisited [nowPos.x, nowPos.y] = true;
		while (queue.Count != 0) {

			k++;
			if (k == 1000)
				break;

			Pos currentPos = queue.Dequeue ();
			//Debug.Log ("cur: " + currentPos.x + ", " + currentPos.y);
			if (currentPos.step + 1 == maxStep)
				break;

			for (int i=1; i<=4; i++) {
				Pos nextPos = currentPos.addPos (moveArray [i]);

				//if (isBricks [nextPos.x, nextPos.y] == WALL) Debug.Log ("Wall!");

				if (nextPos.x < 0 || nextPos.x >= mazeSize ||
				    nextPos.y < 0 || nextPos.y >= mazeSize || 
				    isBricks [nextPos.x, nextPos.y] == WALL ||
				    isVisited [nextPos.x, nextPos.y])
					continue;

				isVisited [nextPos.x, nextPos.y] = true;
				nextPos.setChoiceFrom (currentPos, i);

				if (nextPos.equalTo (endPos)) {
					Debug.Log ("Found!");
					resultPos = nextPos;
					//resultPos = nowPos.addPos (moveArray [nextPos.getChoice ()]);
					break;
				}
				queue.Enqueue (nextPos);
			}
		}

		return resultPos;
	}

	void LoadData (string path)
	{
		TextAsset maze = Resources.Load (path) as TextAsset;
		string [] lines = maze.text.Split ("\n".ToCharArray ());
		for (int i = 0; i < mazeSize; i++) {
			for (int j = 0; j <  mazeSize; j++) {
				isBricks [i, j] = int.Parse (lines [i] [j].ToString ());
			}
		}
	}

	private Pos WorldToLocal(Vector3 worldPos) {
		return new Pos (Mathf.RoundToInt(worldPos.x) + mazeSize / 2, 
		                Mathf.RoundToInt(worldPos.z) + mazeSize / 2, 
		                0);
	}

	private Vector3 LocalToWorld(Pos localPos, float worldY) {
		return new Vector3(localPos.x - mazeSize / 2, worldY, localPos.y - mazeSize / 2);
	}	

}
