using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IggyBounce : MonoBehaviour {

    private Animator _animator;
    [SerializeField] private float bounceForce = 0f;

	// Use this for initialization
	void Start () {
        _animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player") {
            _animator.SetTrigger("Bounced");
            col.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,bounceForce));
        }
    }
}
