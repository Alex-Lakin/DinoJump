using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerraLayEggs : MonoBehaviour {

    private PauseController _pauseController;

    [SerializeField] private GameObject egg;
    [SerializeField] private float eggFrequency;
    private float eggTimer;

    // Use this for initialization
    void Start () {
        _pauseController = GetComponent<PauseController>();
        eggTimer = 0f;
    }
	
	// Update is called once per frame
	void Update () {
		if (_pauseController.paused == false)
        {
            if (eggTimer >= eggFrequency) {
                LayEgg();
            } else {
                eggTimer += 1 * Time.deltaTime;
            }
        }
	}

    private void LayEgg()
    {
        Instantiate(egg, transform.position, transform.rotation, transform.root);
        eggTimer = 0f;
    }
}
