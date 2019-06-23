using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParaFlee : MonoBehaviour {

    private Transform player;
    private Rigidbody2D _ridgedBody;
    private Animator _animator;

    [SerializeField] private float aggroRange;
    [SerializeField] private float moveSpeed;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        _ridgedBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool inRange = CheckPlayerDistance();
        bool playerToRight = CheckPlayerDirection();

        if (inRange == true) {
            if (playerToRight == true)
            {
                _ridgedBody.AddForce(new Vector2(-moveSpeed, 0));
                transform.localScale = new Vector3(-1, 1, 1);
            } else {
                _ridgedBody.AddForce(new Vector2(moveSpeed, 0));
                transform.localScale = new Vector3(1, 1, 1);
            }
            _animator.SetBool("Move", true);
        } else {
            if (playerToRight == true)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            _animator.SetBool("Move", false);
        }
    }

    bool CheckPlayerDistance()
    {
        float myPos = transform.position.x;
        float playerPos = player.position.x;
        float distToPlayer = Vector2.Distance(new Vector2(myPos, 0), new Vector2(playerPos, 0));
        bool inRange;

        if (distToPlayer < aggroRange)
        {
            inRange = true;
        } else {
            inRange = false;
        }

        return inRange;
    }

    bool CheckPlayerDirection()
    {
        float myPos = transform.position.x;
        float playerPos = player.position.x;
        bool playerToRight;
        if (playerPos < myPos) { playerToRight = false; } else { playerToRight = true; }

        return playerToRight;
    }
}
