using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour {

    private Rigidbody2D _ridgedBody;
    private Vector2 storedVelocity;
    private Animator _animator;
    [HideInInspector] public bool paused = false;

	// Use this for initialization
	void Start () {
        _ridgedBody = GetComponent<Rigidbody2D>();
        storedVelocity = new Vector2(0,0);
        _animator = GetComponent<Animator>();
	}
	
    public void PauseObject()
    {
        paused = true;

        if (_ridgedBody != null)
        {
            storedVelocity = _ridgedBody.velocity;
            _ridgedBody.simulated = false;
        }

        if (_animator != null)
        {
            _animator.enabled = false;
        }
    }

    public void UnpauseObject()
    {
        paused = false;

        if (_ridgedBody != null)
        {
            _ridgedBody.simulated = true;
            _ridgedBody.velocity = storedVelocity;
        }

        if (_animator != null)
        {
            _animator.enabled = true;
        }
    }
}
