using UnityEngine;
using System.Collections;

    public class Player : MonoBehaviour
    {

        public float Speed = 0f;
        private float movex = 0f;
        private float movey = 0f;
        Rigidbody2D rgb;

        // Use this for initialization
        void Start()
        {
            rgb = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            movex = Input.GetAxis("Horizontal");
            movey = Input.GetAxis("Vertical");
            rgb.velocity = new Vector2(movex * Speed, movey * Speed);
        }

        public void Death()
        {

        }
    }

