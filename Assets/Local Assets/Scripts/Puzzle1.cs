using UnityEngine;
using System.Collections;

public class Puzzle1 : MonoBehaviour {

	private static int count_collisions = 0;
	public GameObject door;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (count_collisions == 2) {
			Destroy (door);
		}
	}

	void OnTriggerEnter2D(Collider2D stone) {

		count_collisions += 1;
	
	}
}
