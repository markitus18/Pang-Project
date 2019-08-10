using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    //Movement variables
    [Header("Movement")]
    public float maxHeight = 200.0f;

    public float gravityForce = 1.0f;

    public Vector2 velocity;

    public float baseSpeedY = 200.0f;
    public float baseSpeedX = 35.0f;

    //Ball attributes
    [Header("Attributes")]
    public int ballSize = 3;
    public int ballColor = 0;
    
    //Ball components
    Animator animator;
    SpriteRenderer spriteRenderer;

    //Spawnable references
    [Header("References")]
    public GameObject explosionParticle = null;
    public GameObject ballDivisionPrefab = null;

    bool exploded = false;

    // Use this for initialization
    void Start ()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        //TODO: update according to height
        velocity.y = baseSpeedY;
        velocity.x = baseSpeedX;

        float currentHeight = transform.position.y - spriteRenderer.size.y / 2;
        velocity.y = Mathf.Sqrt(baseSpeedY * baseSpeedY - 2 * gravityForce * currentHeight);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (exploded == true) return;

        if (transform.position.y < (0 + spriteRenderer.sprite.rect.height / 2))
            velocity.y = baseSpeedY;

        if (transform.position.x < -184 + spriteRenderer.sprite.rect.width / 2)
            velocity.x = baseSpeedX;

        if (transform.position.x > 184 - spriteRenderer.sprite.rect.width / 2)
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
        //Spawn explosion particle
        GameObject explosionGO = Instantiate(explosionParticle, transform.position, transform.rotation);
        explosionGO.GetComponent<ParticleEffect>().InitialSetup(ballSize, ballColor);

        //Spawn smaller balls (if any)
        if (ballDivisionPrefab != null)
        {
            Vector3 position = transform.position;
            SpriteRenderer renderer = ballDivisionPrefab.GetComponent<SpriteRenderer>();

            GameObject ball1 = Instantiate(ballDivisionPrefab, position + new Vector3(renderer.size.x / 2, 0.0f, 0.0f), Quaternion.identity, gameObject.transform.parent);
            GameObject ball2 = Instantiate(ballDivisionPrefab, position - new Vector3(renderer.size.x / 2, 0.0f, 0.0f), Quaternion.identity, gameObject.transform.parent);

            ball2.GetComponent<Ball>().baseSpeedX = -ball2.GetComponent<Ball>().baseSpeedX;
        }

        //Destroy exploded ball
        Destroy(gameObject);
    }
}
