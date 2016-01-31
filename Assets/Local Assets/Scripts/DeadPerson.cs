using UnityEngine;
using System.Collections;

public class DeadPerson : MonoBehaviour {

	public GameObject player;
    public GameObject playerplayer;
	public GameObject knifePrefab;
	public float speed = 1;
	public Sprite deadSprite;

   
	private bool firstActivity = false, completedFirstActivity = false;
	private bool secondActivity = false, completedSecondActivity = false;
	private bool thirdActivity = false, completedThirdActivity = false;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		if (firstActivity == true && completedFirstActivity == false) {

			MovePlayer ();

		} else if (secondActivity == true && completedSecondActivity == false) {

			Debug.Log ("Activity 2");
			TurnDead ();
		
		} else if (thirdActivity == true && completedThirdActivity == false) {

			Debug.Log ("Activiy 3");
			Knife ();

		}
	}

	void OnMouseDown () {

		if (completedFirstActivity == false) {
		
			firstActivity = true;
		
		} else if (completedSecondActivity == false) {

			secondActivity = true;		
		
		} else if (completedThirdActivity == false) {
		
			thirdActivity = true;

		}

	}

	void MovePlayer() {

		float step = speed * Time.deltaTime;

		if (player.transform.position != transform.position) {
			player.transform.position = Vector3.MoveTowards (player.transform.position, transform.position, step);
		} else {
			completedFirstActivity = true;
		}
	}

	void TurnDead() {

		SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer> ();
		sr.sprite = deadSprite;

		completedSecondActivity = true;
	}

	void Knife() {
       // float xx = 0, yy = 0;
        //xx = player.transform.position.x;
        //yy = player.transform.position.y;

        Destroy(player);
        Instantiate(playerplayer, new Vector2(0f, 0f), Quaternion.identity);

		Instantiate (knifePrefab,  new Vector3(0f, 1f, 0f), Quaternion.identity);
        //Invoke("Destroy(knifePrefab)", 30f);

		completedThirdActivity = true;
	}
}
