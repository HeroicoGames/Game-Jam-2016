
using UnityEngine;
using System.Collections;

public class Trap : MonoBehaviour {

	private SpriteRenderer sprite;
	// Use this for initialization
	void Start () {
		sprite = transform.gameObject.GetComponent<SpriteRenderer> ();
		sprite.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
