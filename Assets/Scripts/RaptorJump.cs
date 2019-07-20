using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaptorJump : MonoBehaviour {

    Rigidbody2D _ridgedBody;

    [SerializeField] private float jumpForce = 0f;
    [SerializeField] private float jumpTimer = 0f;
    private float timer;

    // Use this for initialization
    void Start ()
    {
        _ridgedBody = GetComponent<Rigidbody2D>();
        timer = 0;
    }

    private void Update()
    {
        JumpCounter();
    }

    private void JumpCounter()
    {
        timer += 1 * Time.deltaTime;

        if (timer >= jumpTimer)
        {
            _ridgedBody.AddForce(new Vector2(0, jumpForce));
            timer = 0;
        }
    }
}
