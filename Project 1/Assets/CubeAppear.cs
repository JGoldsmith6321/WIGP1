/*
Q: Can there be more than one gold ore on the screen?
A: Sure, it's a great way to get a super high score but you still have to click a bunch
*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CubeAppear : MonoBehaviour {
	public float spawnTime = 3;
	public float waitTime;
	public GameObject bronze;
	public GameObject silver;
	public GameObject gold;
	public GameObject kryptonite;
	public int bronzeCount = 0;
	public int silverCount = 0;
	public int goldCount = 0;
	public int kryptoniteCount = 0;
	public bool makeKrypt = false;
	public bool hadGold = false;//to check if it's spawned a gold yet
	//Stuff for placing the ores:
	public Vector3 pos;
	public List<Vector3> positions = new List<Vector3>();
	public float xStart = -13;//Having both starts and ends here makes them easy to change later
	public float yStart = 8;
	public float xEnd = 16;
	public float yEnd = -7;
	public float z = 0;
	public float changeXAndYBy = 3;
	public bool pause = false;// just for me checking

	// Use this for initialization
	void Start () {
		MakeScreenSpots ();
		waitTime = Time.time + spawnTime;//time till next ore
	}

	void UpdatePlace (Vector3 posit){//updates places to let an ore be where a destroyed one was
		positions.Add (posit);
	}

	//returns all possible positions of ores while z=0
	void MakeScreenSpots (){
		float x = xStart;
		float y = yStart;
		//Start by keeping x constant
		while (x <= xEnd) {
			while (y >= yEnd) {//go down the y's
				positions.Add (new Vector3(x, y, z));
				y = y - changeXAndYBy;
			}
			y = yStart;
			x = x + changeXAndYBy;//then change x and do again
		}
	}
	
	//makes bronze
	void MakeBronze (){
		Instantiate(bronze,GetPos(),Quaternion.identity);
		hadGold = false;
	}

	//makes Silver
	void MakeSilver (){
		Instantiate(silver,GetPos(),Quaternion.identity);
		hadGold = false;
	}

	//makes gold
	void MakeGold (){
		Instantiate(gold,GetPos(),Quaternion.identity);
		hadGold = true;
	}

	//makes kryptonite
	void MakeKryptonite (){
		Instantiate(kryptonite,GetPos(),Quaternion.identity);
		hadGold = false;
	}

	//Finds a random, untaken position to place an ore into
	Vector3 GetPos (){
		int rand = Random.Range(0, positions.Count-1);
		pos = positions[rand];
		positions.RemoveAt (rand);
		return pos;
	}
	void GetCounts(){//counts all ores on screen
		GameObject[] ores;
		ores = GameObject.FindGameObjectsWithTag("bronze");
		bronzeCount = ores.Length;
		ores = GameObject.FindGameObjectsWithTag("silver");
		silverCount = ores.Length;
		ores = GameObject.FindGameObjectsWithTag("gold");
		goldCount = ores.Length;
		ores = GameObject.FindGameObjectsWithTag("kryptonite");
		kryptoniteCount = ores.Length;
	}
	//sees if should make a kryptonite 
	//kryptonite is not forced to be used as a wild card
	//also not spawned if neither a silver or a gold is on screen
	void SeeIfKrypt (){
		makeKrypt = false;//defaults to not spawn
		if (kryptoniteCount < 2 && 
		    (silverCount + kryptoniteCount == goldCount || silverCount == goldCount + kryptoniteCount || silverCount == goldCount) && 
		    (goldCount > 0 || silverCount > 0))
			{makeKrypt = true;}

	}

	// Update is called once per frame
	void Update () {
		GetCounts ();
		SeeIfKrypt ();
		if (Time.time >= waitTime && pause == false) {//Always spawn after waitTime
			if (makeKrypt == true)
			{MakeKryptonite();}
			else if (bronzeCount == 2 && silverCount == 2 && hadGold == false)//If there are exactly 2 bronze and 2 silver, spawn a gold (yellow cube) instead (but just spawn 1 gold and then go back to the normal rules.)
			{MakeGold ();}
			else if (bronzeCount >= 4)//If there are 4+ bronze, spawn a silver.
			{MakeSilver();}
			else if (bronzeCount<4)//If there are <4 bronze ore, spawn a bronze.
			{MakeBronze ();}
			waitTime=waitTime+spawnTime;//re sets timer for next ore
		}
	}
}
