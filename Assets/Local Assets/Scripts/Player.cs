﻿using UnityEngine;
using System.Collections;

    public class Player : MonoBehaviour
    {

        public float Speed = 0f;
        private float movex = 0f;
        private float movey = 0f;
    GameObject particle;
        Rigidbody2D rgb;
        Animator anim;

        // Use this for initialization
        void Start()
        {
            anim = GetComponent<Animator>();
            rgb = GetComponent<Rigidbody2D>();
        }

    // Update is called once per frame
    void FixedUpdate()
    {
        movex = Input.GetAxis("Horizontal");
        movey = Input.GetAxis("Vertical");
        rgb.velocity = new Vector2(movex * Speed, movey * Speed);


        // The player is not moving.
        if (movex == 0 && movey == 0)
        {
            anim.speed = 0;
        }
        else
        {
            anim.speed = 1;
        }

        // Player move up.
        if (Input.GetKey(KeyCode.W))
        {

            anim.SetBool("up", true);

            anim.SetBool("right", false);
            anim.SetBool("down", false);
            anim.SetBool("left", false);
        }
        // Player move Right.
        else if (Input.GetKey(KeyCode.D))
        {

            anim.SetBool("right", true);

            anim.SetBool("up", false);
            anim.SetBool("down", false);
            anim.SetBool("left", false);
        }
        // Player move down.
        else if (Input.GetKey(KeyCode.S))
        {
            anim.SetBool("down", true);

            anim.SetBool("right", false);
            anim.SetBool("up", false);
            anim.SetBool("left", false);
        }
        // Player move left.
        else if (Input.GetKey(KeyCode.A))
        {
            anim.SetBool("left", true);

            anim.SetBool("right", false);
            anim.SetBool("down", false);
            anim.SetBool("up", false);
        }
    }
   }

