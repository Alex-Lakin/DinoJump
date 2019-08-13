using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    Animator _animator;
    Rigidbody2D _ridgedBody;

    [SerializeField] private float moveForce = 5f;
    [SerializeField] private float maxVelocity = 7f;
    [SerializeField] private bool facingRight;

    void Awake()
    {
        _animator = GetComponent<Animator>();
        _ridgedBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update () {
        Move();
	}

    public void Move()
    {
        float forceX = 0f;

        float vel = Mathf.Abs(_ridgedBody.velocity.x);

        if (facingRight) {
            if (vel < maxVelocity) {
                forceX = moveForce;
            }
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (!facingRight)  {
            if (vel < maxVelocity) {
                forceX = -moveForce;
            }
            transform.localScale = new Vector3(-1, 1, 1);
        }

        _ridgedBody.AddForce(new Vector2(forceX, 0) * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Ground")
        {
            if (gameObject.tag != "Terra")
            {
                facingRight = !facingRight;
            }
        }
    }
}
