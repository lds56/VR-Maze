using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;


public class GenBricks : MonoBehaviour {
	public Transform BrickPrefab;
	public int [,] isBricks;
	//	private Transform[,,] Bricks;
	private int mazeSize = 30;
	private float mazeHeight1 = 0.5f;
	private float mazeHeight2 = 1.5f;
	private float mazeHeight3 = 2.5f;
	private float mazeHeight4 = 3.5f;
	
	// Use this for initialization
	void Start () {
		isBricks = new int [mazeSize, mazeSize];
		//		for (int i = 0; i < mazeSize; i++)
		//			for (int j = 0; j < mazeSize; j++)
		//				isBricks [i, j] = 0;
		//		for (int i = 0; i < mazeSize; i++) {
		//			isBricks [i, 0] = 1;
		//			isBricks [i, mazeSize-1] = 1;
		//		}
		//		for (int i = 0; i < mazeSize - 3; i++) {
		//			isBricks [0, mazeSize-1-i] = 1;
		//			isBricks [mazeSize-1, i] = 1;
		//		}
		//
		//		for (int i = 20; i < 29; i++) {
		//			isBricks [i, 26] = 1;
		//		}
		
		LoadData(Application.dataPath, "maze.txt");
		CreateWall ();
	}
	
	void CreateWall() {
		Transform newBrick;
		//		Transform newBrickTop;
		//		Bricks = new Transform[mazeSize, mazeSize, 2];
		
		for (int i = 0; i < mazeSize; i++) {
			for (int j = 0; j < mazeSize; j++) {
				if (isBricks [i, j] == 1) {
					newBrick = (Transform)Instantiate (BrickPrefab, new Vector3 (i - 15, mazeHeight1, j - 15), Quaternion.identity);
					newBrick = (Transform)Instantiate (BrickPrefab, new Vector3 (i - 15, mazeHeight2, j - 15), Quaternion.identity);
					newBrick = (Transform)Instantiate (BrickPrefab, new Vector3 (i - 15, mazeHeight3, j - 15), Quaternion.identity);
					newBrick = (Transform)Instantiate (BrickPrefab, new Vector3 (i - 15, mazeHeight4, j - 15), Quaternion.identity);
					//					newBrickBase.name = string.Format ("{0}-{1}-base brick", i, j);
					//					newBrickBase.parent = transform;
					//					Bricks [i, j, 0] = newBrickBase;
					
					//					newBrickTop = (Transform)Instantiate (BrickPrefab, new Vector3 (i - 15, mazeHeight2, j - 15), Quaternion.identity);
					//					newBrickTop.name = string.Format ("{0}-{1}-top brick", i, j);
					//					newBrickTop.parent = transform;
					//					Bricks [i, j, 1] = newBrickTop;
					//					Debug.Log("brick "+i+"*"+j+" generated.");
				}
				else
				{
					
				}
			}
		}
	}
	
	void LoadData(string path, string name)
	{
		StreamReader sr = null;
		string line;
		int lineNo = 0;
		
		sr = File.OpenText(path + "//" + name);
		
		while ((line = sr.ReadLine()) != null)
		{
			for (int i = 0; i < mazeSize; i++) {
				isBricks[lineNo, i] = int.Parse (line[i].ToString());
			}
			lineNo++;
		}
		
		sr.Close();
	}
	
}
