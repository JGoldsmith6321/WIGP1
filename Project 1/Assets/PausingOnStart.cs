using UnityEngine;
using System.Collections;


public class PausingOnStart : MonoBehaviour {
	public float timeToSwitch;
	// Use this for initialization
	void Start () {
		timeToSwitch = Time.time + 0.05F;
	}

	void OnGUI (){
		if (Time.time >= timeToSwitch) {
			Application.LoadLevel("2");
		}
	}
	// Update is called once per frame
	void Update () {
	
	}
}
