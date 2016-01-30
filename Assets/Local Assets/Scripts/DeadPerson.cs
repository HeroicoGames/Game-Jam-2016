using UnityEngine;
using System.Collections;

public class DeadPerson : MonoBehaviour {

	public GameObject player;
	public float speed = 1;

	private bool activateMove = false;
	private bool lol = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (activateMove == true) {
			MovePlayer();	
		}
	}

	void OnMouseDown () {

		activateMove = true;

		if (player.transform.position == transform.position){
			// PAss
		}

	}

	void MovePlayer() {

		float step = speed * Time.deltaTime;

		if (player.transform.position != transform.position) {
			player.transform.position = Vector3.MoveTowards (player.transform.position, transform.position, step);
		} else
			activateMove = false;

	}
}
