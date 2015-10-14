//taken from https://unity3d.com/learn/tutorials/modules/beginner/scripting/assignments/spinning-cube because it's two lines of code and works.
using UnityEngine;
using System.Collections;

public class Spin : MonoBehaviour {
	public float speed = 100f;
	public bool go = true;
	// Use this for initialization
	void Start () {

	}

	void OnMouseEnter (){//pause spinning
		go = false;
	}

	void OnMouseExit (){//continues spinning
		go = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (go == true) {
			transform.Rotate (Vector3.up, speed * Time.deltaTime);	
		}
	}
}
