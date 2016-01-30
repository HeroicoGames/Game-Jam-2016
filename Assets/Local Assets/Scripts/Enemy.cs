using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    public GameObject particle;
    private Player instance;

    public float maxSpeed; // 10
    public float acc; // 2
    public Transform target;
    public int moveSpeed;
    public int rotationSpeed;
    float distance = 0f;

    string direction = "";
    public Vector3 min;
    public Vector3 max;
    Rigidbody2D rgb;
    bool followed_player = false;

    float xx;
    float yy;

    /*public Enemy(Vector3 min, Vector3 max)
    {
        this.min = min;
        this.max = max;
    }*/

    void Awake()
    {
        rgb = GetComponent<Rigidbody2D>();
		target = player.transform;//GameObject.Find("Player").transform;
        instance = player.GetComponent<Player>();
    }

    void Start()
    {
        xx = transform.position.x;
        yy = transform.position.y;

        // Set the direction.
        if(min.y == max.y)
        {
            direction = "H";
        }
        else
        {
            direction = "V";
            Debug.Log(direction);
        }

        Debug.Log(direction);
    }

    void Update()
    {

        //Debug.Log("Enemy_x: " + transform.position.x + " Min_x: " + min.x); 

        // If the player is running
        if (instance.is_running)
        {
            distance = 30f;
        }
        else
        {
            distance = 20f;
        }

        // If the player is near enough.
        if(Vector3.Distance(transform.position, player.transform.position) < distance)
        {
            // Follow the Player.
            moveSpeed = 1;
            Follow_Player();

            // The enemy has reached the player.
            if(Vector3.Distance(transform.position, player.transform.position) < 1)
            {
                Death();
            }
        }
        else
        {
            // Patrullar por el escenario, evitando obstaculos.
            if (!followed_player)
            {
                Patrullar(direction, max, min);
            }
            
            // If the enemy followed the player and is not in his position.
            else if(followed_player && (transform.position.x != xx && transform.position.y != yy))
            {
                Debug.Log("I want to return to my position");
                // Make the enemy move to its inicial position.
                Vector3.MoveTowards(transform.position, new Vector2(xx, yy), 10f);

                // If he is in his inicial position, start Patrolling.
                if(transform.position.x == xx && transform.position.y == yy)
                {
                    followed_player = false;
                }
            }
        }

    }

    void Follow_Player()
    {
        followed_player = true;
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
        moveSpeed = 8;
        float step = moveSpeed * Time.deltaTime;

        if (direction == "H"){
            // Change the direction to left.
            if (transform.position.x >= max.x)
            {
                rgb.AddForce(new Vector2(-1f, 0f) * moveSpeed, ForceMode2D.Force);
            }
            // Change the direction to right.
            else if (transform.position.x <= min.x)
            { 
                rgb.AddForce(new Vector2(1f, 0f) * moveSpeed, ForceMode2D.Force);
            }
            // The player is in the middle.
            else
            {
                float dis_min = Vector3.Distance(transform.position, min);
                float dis_max = Vector3.Distance(transform.position, max);

                // Move right.
                if(dis_min < dis_max)
                {
                    rgb.AddForce(new Vector2(1f, 0f) * moveSpeed, ForceMode2D.Force);
                }
                // Move left.
                else
                {
                    rgb.AddForce(new Vector2(-1f, 0f) * moveSpeed, ForceMode2D.Force);
                }
            }
        }
        else if(direction == "V"){
            Debug.Log("Vertical");

            // Change the direction to down.
            if (transform.position.y >= max.y)
            {
                Debug.Log("Move Up");
                rgb.AddForce(new Vector2(0f, -1f) * moveSpeed, ForceMode2D.Force);
            }
            // Change the direction to up.
            else if (transform.position.y <= min.y)
            {
                Debug.Log("Move down");
                rgb.AddForce(new Vector2(0f, 1f) * moveSpeed, ForceMode2D.Force);
            }
            else
            {
                float dis_min = Vector3.Distance(transform.position, min);
                float dis_max = Vector3.Distance(transform.position, max);

                // Move up.
                if (dis_min < dis_max)
                {
                    rgb.AddForce(new Vector2(0f, 1f) * moveSpeed, ForceMode2D.Force);
                }
                // Move down.
                else
                {
                    rgb.AddForce(new Vector2(0f, -1f) * moveSpeed, ForceMode2D.Force);
                }
            }
        }

    }


    void Death()
    {
        // Crear particulas.
        if (GameObject.Find("Particle") == null)
        {
            Instantiate(particle, new Vector3(transform.position.x - 5, transform.position.y - 5, -7f), Quaternion.identity);
        }

        // Cambiar la escena.

    }
}

    