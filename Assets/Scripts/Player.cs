using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    Animator _animator;
    Rigidbody2D _ridgedBody;

    [SerializeField] private float moveForce = 5f;
    [SerializeField] private float jumpForce = 700f;
    [SerializeField] private float maxVelocity = 7f;
    [SerializeField] private float frictionAmount = 0f;

    public bool lockInputs = true;

    void Awake () {
        _animator = GetComponent<Animator>();
        _ridgedBody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        lockInputs = false;
    }

    // Update is called once per frame
    void Update () {
        if (lockInputs == false) { 
            PlayerMove();
        }
    }

    public void PlayerMove()
    {
        float forceX = 0f;
        float forceY = 0f;

        float vel = Mathf.Abs(_ridgedBody.velocity.x);

        float h = Input.GetAxisRaw("Horizontal");
        bool v = Input.GetButtonDown("Jump");

        if (h > 0)
        {
            if (vel < maxVelocity)
            {
                forceX = moveForce;
            }
            _animator.SetBool("RightFacing", true);
            _animator.SetBool("Move", true);
        } else if (h < 0)
        {
            if (vel < maxVelocity)
            {
                forceX = -moveForce;
            }
            _animator.SetBool("RightFacing", false);
            _animator.SetBool("Move", true);
        } else
        {
            Vector2 currentVelocity = _ridgedBody.velocity;
            currentVelocity.x *= frictionAmount;
            _ridgedBody.velocity = currentVelocity;
            _animator.SetBool("Move", false);
        }

        if (v == true)
        {
            if (_animator.GetBool("Grounded") == true)
            {
                forceY = jumpForce;
                _animator.SetBool("Grounded", false);
            }
        }

        _ridgedBody.AddForce(new Vector2(forceX, forceY));
    }

    public void PlayerDead() {
        Vector2 currentVelocity = _ridgedBody.velocity;
        currentVelocity.x = 0;
        _ridgedBody.velocity = currentVelocity;
        _ridgedBody.AddForce(new Vector2(0, 300));
        _animator.SetBool("Grounded", false);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            _animator.SetBool("Grounded", true);
        } else if (col.gameObject.tag == "MovingPlatform")
        {
            _animator.SetBool("Grounded", true);
            transform.SetParent(col.gameObject.transform);
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "MovingPlatform")
        {
            transform.parent = null;
        }
    }

    IEnumerator RestartGame()
    {
        yield return new WaitForSecondsRealtime(1f);

        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "KillBox") {
            lockInputs = true;
            PlayerDead();
            StartCoroutine(RestartGame());
        }
    }
}
