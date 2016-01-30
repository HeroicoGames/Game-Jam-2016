using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOverCanvas : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Restart()
	{
		SceneManager.LoadScene ("MainScene");
	}

	public void MainMenu()
	{
		SceneManager.LoadScene ("MainMenu");
	}
}
