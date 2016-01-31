using UnityEngine;
using System.Collections;

public class Puzzle2 : MonoBehaviour {

    public GameObject door;
    public GameObject[] gears;
	public AudioSource unlockDoor;

    public int numberKey = 0;

	// Use this for initialization
	void Start () {
        numberKey = this.GetComponentInChildren<NumberIndex>().keyIndex;
	}
	
	// Update is called once per frame
	void Update () {

        // If the player completed the puzzle.
        if (Complete(gears))
        {
			unlockDoor.Play ();
            Destroy(door);
        }

	}

    bool Complete(GameObject[] gears)
    {
        // If the puzzle is completed, return true.
        if (gears[0].transform.rotation.eulerAngles.y == 0 &&
            gears[1].transform.rotation.eulerAngles.y == 270 &&
            gears[2].transform.rotation.eulerAngles.y == 90 &&
            gears[3].transform.rotation.eulerAngles.y == 180)
        {
            return true;
        }
        return false;
    }

    void OnTriggerEnter2D(Collider2D stone)
    {

        Debug.Log("Colisión");

        if(stone.gameObject.tag == "Player")
        {
            gears[numberKey].transform.rotation = Quaternion.Euler(0f, 0f, 90f);
        }
        //transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles);

    }
}
