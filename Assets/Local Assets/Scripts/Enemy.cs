using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{

    // Local variables.
    public float patrolSpeed = 5f;
    public float followSpeed = 1f;
    bool found_player = false;
    string direction = "";
    Vector3 distance;

    // Patrol coordinates.
    //public Vector3 max;
    //public Vector3 min;

    public GameObject Player;
    Player script;

    private NavMeshAgent nav;   // Reference to the nav mesh component.
    Animator anim;

    Rigidbody2D rgb;

    // Construct.
    /*public Enemy(Vector3 max, Vector3 min, string direction)
    {
        this.max = max;
        this.min = min;
    }*/


    // Inizialitze components.
    void Awake()
    {
        rgb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();
        script = Player.GetComponent<Player>();
    }

    // Use this for initialization
    void Start()
    {

        // Define the direction of the enemy.
        /*if (max.y == min.y)
        {
            direction = "Horizontal";
        }
        else
        {
            direction = "Vertical";
        }*/
    }

    // Update is called once per frame
    void Update()
    {
 
        // If the enemy found the player.
        float distance = Vector3.Distance(transform.position, Player.transform.position);
        //Debug.LogError("distance: " + distance);


        if (distance < 5)
        {
            Follow_Player(distance, Player.transform.position.x, Player.transform.position.y);
        }
        else
        {
            // The enemy hasn't found the player.
            Patrol();
        }

        // Kill the player.
        if (distance < 1)
        {
            // Kill animation!
            script.Death();

            // Create blood particles!
            for (int i = 0; i < Random.Range(5, 7); i++)
            {
                //Instantiate(Blood, new Vector3(transform.x, transform.y, 0f), 0f);
            }
        }


    }


    // Patrol around the world looking for the player.
    void Patrol()
    {
        /*float step = patrolSpeed * Time.deltaTime;
        // If the direction is vertical.
        if (direction == "Vertical")
        {
            if (transform.position.y <= min.y)
            {
                Vector3.MoveTowards(transform.position, max, step);
            }
            else if (transform.position.x >= max.y)
            {
                Vector3.MoveTowards(transform.position, min, step);
            }
        }
        // If the direction is horizontal.
        else if (direction == "Horizontal")
        {
            if (transform.position.x <= min.x)
            {
                Vector3.MoveTowards(transform.position, max, step);
            }
            else if (transform.position.x >= max.x)
            {
                Vector3.MoveTowards(transform.position, min, step);
            }
        }
        */
    }

    void Follow_Player(float distance, float destination_x, float destination_y)
    {
        float angulo = Mathf.Pow(Mathf.Sin(destination_y) * Mathf.Rad2Deg, -1);
        float x_component = Mathf.Cos(angulo) * distance;
        float y_component = Mathf.Sin(angulo) * distance;
        rgb.velocity = new Vector2(x_component * followSpeed, y_component * followSpeed);


        //rgb.AddForce(move * Time.deltaTime, ForceMode2D.Impulse);



        //Vector2.MoveTowards(transform.position, Player.transform.position, followSpeed);

        /* Calculate if path is posible.
        bool path = nav.CalculatePath(Player.transform.position, 1);

        // If path is possible follow the player.
        if (path)
        {
            // Accelerate the Enemy.
            nav.acceleration = 5;

            // Set the enemy's destination.
            nav.destination = new Vector3(destination_x, destination_y);

            // Set found_player to true.
            found_player = true;
        }
        */
    }
    
}

    