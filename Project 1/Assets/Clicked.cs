using UnityEngine;
using System.Collections;

public class Clicked : MonoBehaviour {
	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {

	}
	void OnMouseDown(){
		GameObject.FindGameObjectWithTag("Score").SendMessage("UpdateScore", this.tag);
		Vector3 position =  (new Vector3(transform.position.x, transform.position.y, 0));//finds poition to send
		GameObject.FindGameObjectWithTag("CubeAppear").SendMessage("UpdatePlace", position);
		Destroy (this.gameObject);
	}
}