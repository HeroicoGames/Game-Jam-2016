using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;


public class BlurManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		removeBlur ();
	}

	void removeBlur() {
		
		BlurOptimized b = gameObject.GetComponent<BlurOptimized> ();
		b.downsample = 0;
		b.blurSize = 0;
	}
}
