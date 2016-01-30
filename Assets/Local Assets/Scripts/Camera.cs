using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {

	public GameObject Player;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, -10);
		//transform.LookAt (Player.transform.position);
	}
}
