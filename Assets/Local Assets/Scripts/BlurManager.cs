using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;


public class BlurManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine ("removeBlur");
	}
	
	// Update is called once per frame
	void Update () {

	}

	IEnumerator removeBlur() {
		BlurOptimized b = gameObject.GetComponent<BlurOptimized> ();

		for (int i = 20; i >= 0; i -= 1) {

			// b.downsample -= 1;
			b.blurSize -= 0.5f;
			// b.blurIterations -= 1;

			yield return new WaitForSeconds(0.5f);
		}

		yield return new WaitForSeconds (0.5f);
		b.downsample = 0;

		yield return new WaitForSeconds (0.5f);
		b.blurIterations = 2;

		yield return new WaitForSeconds (0.5f);
		b.blurIterations = 1;

		yield return new WaitForSeconds (0.5f);
		b.enabled = false;
			
	}
}
