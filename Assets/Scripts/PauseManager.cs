using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour {

    private PauseController[] activeObjects;
    private bool paused = false;
    private Player _player;

	// Use this for initialization
	void Start () {
        _player = GameObject.Find("Dino").GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
        bool i = Input.GetButtonDown("Pause");
        if (i) {
            if (paused) {
                UnpauseGame();
            } else {
                PauseGame();
            }
        }
	}

    private void PauseGame()
    {
        paused = true;

        activeObjects = GetComponentsInChildren<PauseController>();
        foreach (PauseController activeObject in activeObjects)
        {
            activeObject.PauseObject();
        }

        _player.lockInputs = true;
    }

    private void UnpauseGame()
    {
        paused = false;
        
        foreach (PauseController activeObject in activeObjects)
        {
            activeObject.UnpauseObject();
        }

        activeObjects = null;

        _player.lockInputs = false;
    }
}
