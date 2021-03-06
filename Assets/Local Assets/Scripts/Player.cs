﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Player : MonoBehaviour
{

	public float Speed = 0f;
	public float runSpeed = 0f;
	private float movex = 0f;
	private float movey = 0f;
	private	int countDivineObjects = 0;
	public bool is_running = false;
	public GameObject door;
	Rigidbody2D rgb;
	Animator anim;
	private bool isOpen;

	// Use this for initialization
	void Start ()
	{
		anim = GetComponent<Animator> ();
		rgb = GetComponent<Rigidbody2D> ();
		isOpen = false;
	}

	// Update is called once per frame
	void FixedUpdate ()
	{

		movex = Input.GetAxis ("Horizontal");
		movey = Input.GetAxis ("Vertical");

		if (Input.GetKey (KeyCode.Space)) {
			rgb.velocity = new Vector2 (movex * runSpeed, movey * runSpeed);
			is_running = true;
		} else {
			rgb.velocity = new Vector2 (movex * Speed, movey * Speed);
			is_running = false;
		}


		// The player is not moving.
		if (movex == 0 && movey == 0) {
			anim.speed = 0;
		} else {
			anim.speed = 1;
		}

		// Player move up.
		if (Input.GetKey (KeyCode.W)) {

			anim.SetBool ("up", true);

			anim.SetBool ("right", false);
			anim.SetBool ("down", false);
			anim.SetBool ("left", false);
		}
	        // Player move Right.
	        else if (Input.GetKey (KeyCode.D)) {

			anim.SetBool ("right", true);

			anim.SetBool ("up", false);
			anim.SetBool ("down", false);
			anim.SetBool ("left", false);
		}
	        // Player move down.
	        else if (Input.GetKey (KeyCode.S)) {
			anim.SetBool ("down", true);

			anim.SetBool ("right", false);
			anim.SetBool ("up", false);
			anim.SetBool ("left", false);
		}
	        // Player move left.
	        else if (Input.GetKey (KeyCode.A)) {
			anim.SetBool ("left", true);

			anim.SetBool ("right", false);
			anim.SetBool ("down", false);
			anim.SetBool ("up", false);
		}
		Debug.Log ("conteo: "+countDivineObjects+" abierto: "+isOpen);
		if (countDivineObjects == 4 && !isOpen) {
			//Destroy (door);
			isOpen = true;
		}
	}

	public void PlayerDeath ()
	{
		Destroy (gameObject, 2.0f);
		SceneManager.LoadScene ("GameOver");
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.CompareTag ("Trap")) {
			PlayerDeath ();
		}

		if (col.gameObject.CompareTag ("DivineObject")) {
			countDivineObjects = countDivineObjects + 1;
		}

		if (col.gameObject.CompareTag ("ExitDoor") && isOpen) {
			SceneManager.LoadScene ("FinalScene");
		}
	}
}

