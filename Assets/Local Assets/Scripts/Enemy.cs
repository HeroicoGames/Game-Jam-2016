using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    public float maxSpeed; // 10
    public float acc; // 2
    public Transform target;
    public int moveSpeed;
    public int rotationSpeed;

    void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    void Update()
    {
        // If the player is near enough.
        if(Vector3.Distance(transform.position, player.transform.position) < 5)
        {
            // Follow the Player.
            Follow_Player();
        }
        else
        {   
            // Patrullar por el escenario, evitando obstaculos.
            Patrullar();
        }

    }

    void Follow_Player()
    {
        if (target != null)
        {
            Vector3 dir = target.position - transform.position;
            // Only needed if objects don't share 'z' value.
            dir.z = 0.0f;
            if (dir != Vector3.zero)
                transform.rotation = Quaternion.Slerp(transform.rotation,
                    Quaternion.FromToRotation(Vector3.right, dir),
                    rotationSpeed * Time.deltaTime);

            //Move Towards Target
            Vector3 Suma = ((target.position - transform.position).normalized * moveSpeed * Time.deltaTime) * acc;
            if(acc < 5)
            {
                acc += 0.5f;
            }
            transform.position += Suma;

         

        }
        GetComponent<Rigidbody2D>().velocity = Vector3.zero;
    }

    void Patrullar()
    {

    }
}

    