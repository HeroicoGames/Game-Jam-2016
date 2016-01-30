using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    public GameObject particle;
    public float maxSpeed; // 10
    public float acc; // 2
    public Transform target;
    public int moveSpeed;
    public int rotationSpeed;
    NavMeshAgent nav;

    Vector3 min;
    Vector3 max;
    string direction = "";

    public Enemy(Vector3 min, Vector3 max)
    {
        this.min = min;
        this.max = max;
    }


    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        target = GameObject.Find("Player").transform;

        // Set the direction.
        if(min.y == max.y)
        {
            direction = "H";
        }
        else
        {
            direction = "V";
        }
        
    }

    void Update()
    {
        // If the player is near enough.
        if(Vector3.Distance(transform.position, player.transform.position) < 5)
        {
            // Follow the Player.
            Follow_Player();

            // The enemy has reached the player.
            if(Vector3.Distance(transform.position, player.transform.position) < 1)
            {
                // Create blood particles.
                Instantiate(particle, new Vector3(transform.position.x, transform.position.y, -7f), Quaternion.identity);

                // Game Over.

            }
        }
        else
        {   
            // Patrullar por el escenario, evitando obstaculos.
            Patrullar(direction, min, max);
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

    // Patrullar por el mundo evitando obstaculos.
    void Patrullar(string direction, Vector3 max, Vector3 min)
    {

        float step = moveSpeed * Time.deltaTime;
        if (direction == "H"){
            if (transform.position.x > max.x)
            {                 
                Vector3.MoveTowards(transform.position, min, step);
            }
            else if(transform.position.x < min.x)
            {
                Vector3.MoveTowards(transform.position, max, step);
            }
        }else if(direction == "V"){
            if (transform.position.y > max.y)
            {
                Vector3.MoveTowards(transform.position, min, step);
            }
            else if (transform.position.y < min.y)
            {
                Vector3.MoveTowards(transform.position, max, step);
            }
        }


    }
}

    