﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float maxHeight = 200.0f;

    public float gravityForce = 1.0f;

    Vector2 velocity;

    public float baseSpeedY = 200.0f;
    public float baseSpeedX = 35.0f;

    bool exploded = false;
    Animator animator;

    public GameObject explosionParticle;

    // Use this for initialization
    void Start ()
    {
        animator = GetComponent<Animator>();

        //TODO: update according to height
        velocity.y = baseSpeedY;
        velocity.x = baseSpeedX;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (exploded == true) return;

        if (transform.position.y < -48)
            velocity.y = baseSpeedY;

        if (transform.position.x < -160)
            velocity.x = baseSpeedX;

        if (transform.position.x > 160)
            velocity.x = -baseSpeedX;

        velocity.y -= gravityForce * Time.deltaTime;
        transform.Translate(new Vector3(velocity.x * Time.deltaTime, velocity.y * Time.deltaTime, 0));
	}

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        Debug.Log("Collision entered");

        if (otherCollider.gameObject.CompareTag("Brick"))
        {

        }
    }

    public void Explode()
    {
        Instantiate(explosionParticle, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}