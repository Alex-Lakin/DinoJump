using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelection : MonoBehaviour {

    private LevelManager levelManager;

    [HideInInspector] public float currentlySelectedLevelNumber;

	// Use this for initialization
	void Start () {
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SendCurrentlyselectedLevelToLevelManager()
    {
        levelManager.GoToLevel(currentlySelectedLevelNumber);
    }
}
