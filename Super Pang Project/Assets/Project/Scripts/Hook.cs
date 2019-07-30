using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour {

    SpriteRenderer spriteRenderer;
    BoxCollider2D boxCollider;

	// Use this for initialization
	void Start ()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update ()
    {
        boxCollider.size = new Vector2(boxCollider.size.x, spriteRenderer.sprite.bounds.size.y);
        boxCollider.offset = new Vector2(boxCollider.offset.x, boxCollider.size.y / 2);
    }
}
