using UnityEngine;
using System.Collections;

public class CubeAppear : MonoBehaviour {
	public float waitTime;
	public GameObject cube;
	public bool hasCube;
	public float timeWaiting;

	// Use this for initialization
	void Start () {
		timeWaiting = 1F;
		waitTime = Time.time + timeWaiting;
		hasCube = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time >= waitTime && hasCube==false) {
			cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
			hasCube = true;
		}
	}
}
