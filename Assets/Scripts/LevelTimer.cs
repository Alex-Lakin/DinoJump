using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LevelTimer : MonoBehaviour {

    private PauseController _pauseController;

    private GameObject tcGameObject;
    private NumberStringToImages timerCounter;

    private float timerTime;

    private string totalTime;

    // Use this for initialization
    void Start () {
        tcGameObject = GameObject.Find("TimerCount");
        timerCounter = tcGameObject.GetComponent<NumberStringToImages>();
        _pauseController = GetComponent<PauseController>();
        
        timerTime = 0f;
    }
	
	// Update is called once per frame
	void Update () {
        if (_pauseController.paused == false)
        {
            timerTime += Time.deltaTime;

            int minutesInt = (int)timerTime / 60;
            int secondsInt = (int)timerTime % 60;
            int hundredthsInt = (int)(Mathf.Floor((timerTime - (secondsInt + minutesInt * 60)) * 100));

            string minutesString = (minutesInt < 10) ? "0" + minutesInt : minutesInt.ToString();
            string secondsString = (secondsInt < 10) ? "0" + secondsInt : secondsInt.ToString();
            string hundredthsString = (hundredthsInt < 10) ? "0" + hundredthsInt : hundredthsInt.ToString();

            totalTime = minutesString + secondsString + hundredthsString;

            if (timerCounter != null)
            {
                timerCounter.StringToImages(totalTime);
            }
        }
    }

    public void DestroyVisableTimer() {
        Destroy(tcGameObject);
        timerCounter = null;
    }

    public string SendEndTime()
    {
        return totalTime;
    }
}
