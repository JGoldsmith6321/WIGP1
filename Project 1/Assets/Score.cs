using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {
	public int score = 0;
	public int bronzePoints = 1;
	public int silverPoints = 10;
	public int goldPoints = 100;
	public int kryptonitePoints = 1000;
	//for text
	public string timeTxt;
	public GameObject textgameobject;
	public int addedScore;
	public float scoreAddedAt = -2F;//set so it doesn't show at atart

	// Use this for initialization
	void Start () {
	
	}

	void GetTime (){//sets time as text
		int time = (int)Time.time;
		int hr = 0;
		int min = 0;		
		while (time >= 3600) {//over an hr
			time = time - 3600;
			hr++;
		}
		while (time >= 60) {//over a min
			time = time - 60;
			min++;
		}

		if (time < 10) {//format millisecs
			timeTxt = "0" + time;
		} else if (time < 1){
			timeTxt = "00";
		} else {
			timeTxt = "" + time;
		}

		if (hr >= 1) {
			if (min < 10){
				timeTxt = "Time: " + hr + ":0" + min + ":" + timeTxt;
			}
			else{
				timeTxt = "Time: " + hr + ":" + min + ":" + timeTxt;
			}
		} else if (min >= 1) {
			if (min < 10){
				timeTxt = "Time: 0" + min + ":" + timeTxt;
			}
			else{
				timeTxt = "Time: " + min + ":" + timeTxt;
			}
		} else {
			timeTxt = "Time: "+timeTxt;
		}
	}

	public void UpdateScore(string tag) {
		if (tag == "bronze") {
			score = score + bronzePoints;
			addedScore = bronzePoints;
			scoreAddedAt = Time.time;
		} else if (tag == "silver") {
			score = score + silverPoints;
			addedScore = silverPoints;
			scoreAddedAt = Time.time;
		} else if (tag == "gold") {
			score = score + goldPoints;
			addedScore = goldPoints;
			scoreAddedAt = Time.time;
		} else if (tag == "kryptonite") {
			score = score + kryptonitePoints;
			addedScore = kryptonitePoints;
			scoreAddedAt = Time.time;
		}

	}
	// Update is called once per frame
	void Update () {
		Text text = textgameobject.GetComponent<Text>();
		GetTime ();
		if (scoreAddedAt + 1 >= Time.time) {
			text.text = timeTxt + " Score: " + score + " +"+addedScore;
		} 
		else {
		
			text.text = timeTxt + " Score: " + score;
		}
	}
}
