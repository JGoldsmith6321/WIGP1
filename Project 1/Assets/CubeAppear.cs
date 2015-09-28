/*
1) When the game starts, the player should see a blank scene.

2) Every createBronzeTime seconds, a bronze ore (i.e. a red cube) appears.

	a. Note: It should be obvious to the player that more ore is appearing over time, so don't put the new bronze ore 
		in the same place as existing ore, and ensure the new ore appears someplace the player can see it.

3) After switchToSilverTime seconds, instead of spawning bronze ore, spawn silver ore (i.e. a white cube).

4) After an additional stopSpawningTime seconds, stop spawning ore.

Use the values below for the variables mentioned, but they should be easily changeable in the Inspector:
createBronzeTime = 3
switchToSilverTime = 12
stopSpawningTime = 6
*/
/*
confusions:
Q: Do the silver spawn every 3 secounds?
A: sure, for 6 six secounds, that's only two silvers.
 */
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CubeAppear : MonoBehaviour {
	public float createBronzeTime = 3;
	public float switchToSilverTime = 12;
	public float stopSpawningTime = 6;
	public float waitTime;
	public GameObject bronze;
	public GameObject silver;
	public float endTime;
	public Vector3 pos;
	public List<Vector3> positions = new List<Vector3>();
	public float xStart = -19;//Having both starts and ends here makes them easy to change later
	public float yStart = 8;
	public float xEnd = 17;
	public float yEnd = -7;
	public float z = 0;
	public float changeXAndYBy = 3;
	public float time;// just for me checking

	// Use this for initialization
	void Start () {
		MakeScreenSpots ();
		waitTime = Time.time + createBronzeTime;//time till next ore
		endTime = Time.time + switchToSilverTime + stopSpawningTime;//tells to end spawning
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
	}

	//makes Silver
	void MakeSilver (){
		Instantiate(silver,GetPos(),Quaternion.identity);
	}

	//Finds a random, untaken position to place an ore into
	Vector3 GetPos (){
		int rand = Random.Range(0, positions.Count-1);
		pos = positions[rand];
		positions.RemoveAt (rand);
		return pos;
	}

	// Update is called once per frame
	void Update () {
		time = Time.time;// just for me checking
		if (Time.time >= waitTime && Time.time <= endTime) {
			if (Time.time >= switchToSilverTime)
			{MakeSilver();}
			else 
			{MakeBronze ();}
			waitTime=waitTime+createBronzeTime;//re sets timer for next ore
		}
	}
}
