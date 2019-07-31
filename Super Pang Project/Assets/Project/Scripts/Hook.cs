using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour {

    SpriteRenderer spriteRenderer;
    BoxCollider2D hookCollider;

	// Use this for initialization
	void Start ()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        hookCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update ()
    {
        hookCollider.size = new Vector2(hookCollider.size.x, spriteRenderer.sprite.bounds.size.y);
        hookCollider.offset = new Vector2(hookCollider.offset.x, hookCollider.size.y / 2);
    }

    public void OnAnimationFinished()
    {
        OnSolidBrickHit();
    }

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Brick"))
        {
            OnSolidBrickHit();
        }
        if (otherCollider.gameObject.CompareTag("DestroyableBrick"))
        {
            OnDestroyableBrickHit();
        }
        if (otherCollider.gameObject.CompareTag("Ball"))
        {
            OnBallHit(otherCollider.gameObject);
        }
    }

    void OnSolidBrickHit()
    {
        Destroy(gameObject);
    }

    void OnDestroyableBrickHit()
    {
        Destroy(gameObject);
    }

    void OnBallHit(GameObject ballGO)
    {
        Ball ball = ballGO.GetComponent<Ball>();
        ball.Explode();
        Destroy(gameObject);
    }

}
