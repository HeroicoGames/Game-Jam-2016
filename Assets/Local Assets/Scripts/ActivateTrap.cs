using UnityEngine;
using System.Collections;

public class ActivateTrap : MonoBehaviour {

	public GameObject trap;
	private SpriteRenderer trapSprite;
	// Use this for initialization
	void Start () {
		trapSprite = trap.gameObject.GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.CompareTag("Player"))
		{
			trapSprite.enabled = true;
		}
	}
}
