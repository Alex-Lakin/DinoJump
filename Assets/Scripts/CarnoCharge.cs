using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarnoCharge : MonoBehaviour {
    
    private Transform player;
    private Rigidbody2D _ridgedBody;

    [SerializeField] private float aggroRange;
    [SerializeField] private float chargeForce;
    
    private bool isCharging = false;

    // Use this for initialization
    void Start () {
        player = GameObject.FindWithTag("Player").transform;
        _ridgedBody = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        CheckForPlayer();

        if (isCharging == true)
        {
            _ridgedBody.AddForce(new Vector2(chargeForce * transform.localScale.x, 0));
        }
	}

    void CheckForPlayer()
    {
        float myPos = transform.position.x;
        float playerPos = player.position.x;
        bool playerToRight;
        if (playerPos < myPos) { playerToRight = false; } else { playerToRight = true;}
        bool rightFacing;
        if (transform.localScale.x > 0) { rightFacing = true;} else { rightFacing = false;}
        float distToPlayer = Vector2.Distance(new Vector2(myPos, 0), new Vector2(playerPos, 0));

        if (distToPlayer < aggroRange) {
            if (rightFacing == playerToRight)
            {
                isCharging = true;
            } else {
                isCharging = false;
            }
        }
    }

    
}
