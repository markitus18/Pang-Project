using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEffect : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void OnAnimationFinished()
    {
        Destroy(gameObject);
    }

    public void InitialSetup(int ballSize, int ballColor)
    {
        Animator animator = GetComponent<Animator>();
        if (animator != null)
        {
            animator.SetInteger("ballSize", ballSize);
            animator.SetInteger("ballColor", ballColor);
        }
    }
}
