using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenuCanvasManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StartGame()
	{
		SceneManager.LoadScene ("First");
	}

	public void Credits()
	{
		SceneManager.LoadScene ("Credits");
	}

	public void Exit()
	{
		Application.Quit ();
	}
}
