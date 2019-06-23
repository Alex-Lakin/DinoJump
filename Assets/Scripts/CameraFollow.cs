using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    private Transform player;

    [SerializeField] private float minX;
    [SerializeField] private float maxX;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
        if (player != null) {
            Vector3 temp = transform.position;
            temp.x = player.position.x;

            if (temp.x < minX)
            {
                temp.x = minX;
            }
            if (temp.x > maxX)
            {
                temp.x = maxX;
            }

            transform.position = temp;
        }
	}
}
