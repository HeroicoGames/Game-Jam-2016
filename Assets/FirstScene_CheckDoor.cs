using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class FirstScene_CheckDoor : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D col)
    {
        SceneManager.LoadScene("MainScene");
    }
}
