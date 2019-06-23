using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UnpauseOnClick()
    {
        PauseManager pauseManager = GameObject.Find("PauseManager").GetComponent<PauseManager>();
        pauseManager.UnpauseGame();
    }
}
