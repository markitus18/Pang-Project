using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public GameObject hookPrefab;

    public float walkSpeed = 1.0f;
    Animator animator;
    SpriteRenderer spriteRenderer;

    bool shooting = false;

	// Use this for initialization
	void Start ()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        bool run = false;

        if (shooting == false)
        {
		    if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(new Vector3(-1.0f * walkSpeed, 0.0f, 0.0f));
                spriteRenderer.flipX = true;
                run = true;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(new Vector3(1.0f * walkSpeed, 0.0f, 0.0f));
                spriteRenderer.flipX = false;
                run = true;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                shooting = true;
                animator.SetBool("shooting", true);
                Instantiate(hookPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            }
        }

        if (animator.GetBool("running") != run)
            animator.SetBool("running", run);
    }

    public void OnShotFinished()
    {
        shooting = false;
        animator.SetBool("shooting", false);
    }
}
