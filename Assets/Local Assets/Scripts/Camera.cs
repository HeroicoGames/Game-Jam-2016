using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {

	public GameObject Player;
	private float minXCamera;
	private float minYCamera;
	private float maxXCamera;
	private float maxYCamera;
	private float positionX;
	private float positionY;
	// Use this for initialization
	void Start () {
		minXCamera = -36.6f;
		minYCamera = -21.8f;
		maxXCamera = 33.6f;
		maxYCamera = 27f;

		transform.position = new Vector3(Player.transform.position.x, minYCamera,-10);
	}
	
	// Update is called once per frame
	void Update () {
		if (Player.transform.position.x > minXCamera && Player.transform.position.x < maxXCamera) {
			positionX = Player.transform.position.x;
		} else {
			positionX = transform.position.x;
		}
		if (Player.transform.position.y > minYCamera && Player.transform.position.y < maxYCamera) {
			positionY = Player.transform.position.y;
		} else {
			positionY = transform.position.y;
		}
		transform.position = new Vector3(positionX, positionY, -10);
		//transform.LookAt (Player.transform.position);
	}
}
