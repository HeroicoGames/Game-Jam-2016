using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private float speed;
	private Vector2 playerPosition;
	// Use this for initialization
	void Start () {
		speed = 2.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.UpArrow))
		{
			Move (0, 1);
		}
		if(Input.GetKey(KeyCode.DownArrow))
		{
			Move (0,-1);
		}
		if(Input.GetKey(KeyCode.LeftArrow))
		{
			Move (-1,0);
		}
		if(Input.GetKey(KeyCode.RightArrow))
		{
			Move (1,0);
		}
	
	}

	public void Move(float stepX, float stepY)
	{
		Vector3 newPosition = new Vector3 (transform.position.x+stepX*speed*Time.deltaTime,transform.position.y+stepY*speed*Time.deltaTime, 0f);
		transform.position = newPosition;
		stepX = 0;
		stepY = 0;
	}
}
