using UnityEngine;
using System.Collections;

public class ActivateTrap : MonoBehaviour {

	public GameObject trap;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.CompareTag("Player"))
		{
			trap.SetActive (true);
		}
	}
}
