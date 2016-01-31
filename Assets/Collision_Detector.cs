using UnityEngine;
using System.Collections;

public class Collision_Detector : MonoBehaviour {

    public GameObject[] gears;
    public GameObject door;

    void Update()
    {
        // If the gears are in position.
        if (Complete(gears))
        {
            // Destroy the door.
            Destroy(door);
        }

 
    }
   
    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "Key") {
            col.gameObject.transform.Rotate(0f, 0f, 90f);
        }
    }

    bool Complete(GameObject[] gears)
    {
        
       

        // If the puzzle is completed, return true.
        if (gears[0].transform.rotation.eulerAngles.z == 90 &&
            gears[1].transform.rotation.eulerAngles.z == 180 &&
            gears[2].transform.rotation.eulerAngles.z == 0 &&
            gears[3].transform.rotation.eulerAngles.z == 270)
        {

            return true;
        }
        return false;
    }



}