using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    public GameObject particle;
    private Player instance;


    public Transform target;
    public int RunSpeed;
    public int patrolSpeed;
    public int rotationSpeed;
    float distance = 0f;

    private AudioSource RunPlayer;

    string direction = "";
    public Vector3 min;
    public Vector3 max;
    Rigidbody2D rgb;
    bool followed_player = false;
    bool follow_player = false;
     
    float xx;
    float yy;

    /*public Enemy(Vector3 min, Vector3 max)
    {
        this.min = min;
        this.max = max;
    }*/

    void Awake()
    {
        RunPlayer = GetComponent<AudioSource>();
        rgb = GetComponent<Rigidbody2D>();
        target = GameObject.Find("Nigga").transform;
       // instance = player.GetComponent<Player>();
    }

    void Start()
    {
        xx = transform.position.x;
        yy = transform.position.y;

        // Set the direction.
        if(min.y == max.y)
        {
            direction = "H";
            transform.Rotate(0f, 0f, 90f);
        }
        else
        {
            direction = "V";
        }
		Debug.Log(direction);
    }

 
    void Update()
    {
        // If the enemy is not following the player or is not returning from where he was.

        if (!follow_player && !followed_player)
        {
            Patrullar(direction, max, min);
        }
        else if (followed_player)
        {
            // Regresar a donde estaba.
            Vector2 pos = new Vector2(xx, yy);
            //Vector3.MoveTowards(transform.position, pos, 10f);

            transform.position = pos;

            // If the player returned where he was.
            if (Vector2.Distance(transform.position, pos) < 1)
            {
                Death();
                followed_player = false;
            }
        }
    }

    // The player is in the range of the enemy.
    void OnTriggerStay2D(Collider2D stone)
    {
		if(stone.gameObject.CompareTag("Player"))
		{
			Follow_Player();
		}
    }

    // The player escaped from the enemy.
    void OnTriggerExit2D(Collider2D stone)
    {
		if (stone.gameObject.CompareTag ("Player")) {
			follow_player = false;
			followed_player = true;
		}
    }

    // Kill the player!
    void OnCollisionEnter2D(Collision2D stone)
    {
		if(stone.gameObject.CompareTag("Player"))
		{
			Death();
		}
    }   
    


    void Follow_Player()
    {
        //RunPlayer.playOnAwake();
        follow_player = true;
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
            Vector3 Suma = ((target.position - transform.position).normalized * RunSpeed * Time.deltaTime);
            transform.position += Suma;

         

        }
        GetComponent<Rigidbody2D>().velocity = Vector3.zero;
    }

    // Patrullar por el mundo evitando obstaculos.
    void Patrullar(string direction, Vector3 max, Vector3 min)
    {

        if (direction == "H"){
            // Change the direction to left.
            if (transform.position.x >= max.x)
            {
                rgb.AddForce(new Vector2(-1f, 0f) * patrolSpeed, ForceMode2D.Force);
            }
            // Change the direction to right.
            else if (transform.position.x <= min.x)
            {
                rgb.AddForce(new Vector2(1f, 0f) * patrolSpeed, ForceMode2D.Force);
            }
            // The player is in the middle.
            else
            {
                float dis_min = Vector3.Distance(transform.position, min);
                float dis_max = Vector3.Distance(transform.position, max);

                // Move right.
                if(dis_min < dis_max)
                {
                    rgb.AddForce(new Vector2(1f, 0f) * patrolSpeed, ForceMode2D.Force);
                }
                // Move left.
                else
                {
                    rgb.AddForce(new Vector2(-1f, 0f) * patrolSpeed, ForceMode2D.Force);
                }
            }
        }
        else if(direction == "V"){

            // Change the direction to down.
            if (transform.position.y >= max.y)
            {
                rgb.AddForce(new Vector2(0f, -1f) * patrolSpeed, ForceMode2D.Force);
            }
            // Change the direction to up.
            else if (transform.position.y <= min.y)
            {
                rgb.AddForce(new Vector2(0f, 1f) * patrolSpeed, ForceMode2D.Force);
            }
            else
            {
                float dis_min = Vector3.Distance(transform.position, min);
                float dis_max = Vector3.Distance(transform.position, max);

                // Move up.
                if (dis_min < dis_max)
                {
                    rgb.AddForce(new Vector2(0f, 1f) * patrolSpeed, ForceMode2D.Force);
                }
                // Move down.
                else
                {
                    rgb.AddForce(new Vector2(0f, -1f) * patrolSpeed, ForceMode2D.Force);
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