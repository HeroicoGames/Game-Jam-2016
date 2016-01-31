using UnityEngine;
using System.Collections;

public class FirstScene : MonoBehaviour {

	public GameObject ilustration1;
	public GameObject ilustration2;
	public GameObject ilustration3;

	private GameObject[] firstObjects;

	// Use this for initialization
	void Start () {
		Invoke ("first_to_two", 15f);
		Invoke ("two_to_three", 20f);
		Invoke ("three_to_gameplay", 25f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void first_to_two(){
		ilustration1.SetActive (false);
		ilustration2.SetActive (true);
	}

	void two_to_three(){
		ilustration2.SetActive (false);
		ilustration3.SetActive (true);
	}

	void three_to_gameplay(){
	
		ilustration3.SetActive (false);

		GameObject background = GameObject.Find ("background-test");
		background.transform.position = new Vector3 (-0.02f, 0.07f, 0f);

		GameObject nigga = GameObject.Find ("NiggaAtado");
		nigga.transform.position = new Vector3 (-1.6f, 0f, 0f);

		GameObject deadPeople = GameObject.Find ("deadPeople");
		deadPeople.transform.position = new Vector3 (0f, -1f, 0f); // 1.2

		GameObject door = GameObject.Find ("door");
		door.transform.position = new Vector3 (-3f, 0f, 0f); // 4.6
	}
}
