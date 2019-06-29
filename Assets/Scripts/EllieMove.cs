using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EllieMove : MonoBehaviour {

    private PauseController _pauseController;

    [SerializeField] float swimSpeed;

	// Use this for initialization
	void Start () {
        _pauseController = GetComponent<PauseController>();
	}
	
	// Update is called once per frame
	void Update () {
        if (_pauseController.paused == false) {
            Swim();
        }
    }

    private void Swim()
    {
        Vector2 pos = transform.position;
        pos.x += (swimSpeed * transform.localScale.x) * Time.deltaTime;
        transform.position = pos;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ground") {
            transform.localScale = new Vector3(transform.localScale.x * -1, 1, 1);
        }
    }
}
