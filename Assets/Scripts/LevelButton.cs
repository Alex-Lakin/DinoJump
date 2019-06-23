using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LevelButton : MonoBehaviour {

    private LevelManager levelManager;

    private GameObject levelSelectButton;
    private NumberStringToImages bestTime;
    [SerializeField] private int levelNumber;
    private bool levelIsUnlocked = false;

	// Use this for initialization
	void Start () {
        levelSelectButton = GameObject.Find("StartLevel");
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        foreach (CompletedLevels level in levelManager.completedLevelList)
        {
            if (level.levelUnlocked == levelNumber)
            {
                levelIsUnlocked = true;
            }
        }

        bestTime = GameObject.Find("BestTime").GetComponent<NumberStringToImages>();
	}

    public void SetLevelSelectButtonTo(float levelNumber)
    {
        Button startButtonComponent = levelSelectButton.GetComponent<Button>();
        startButtonComponent.interactable = levelIsUnlocked;
        LevelSelection levelSelectButtonScript = levelSelectButton.GetComponent<LevelSelection>();
        levelSelectButtonScript.currentlySelectedLevelNumber = levelNumber;
        foreach (CompletedLevels level in levelManager.completedLevelList)
        {
            if (level.levelUnlocked == levelNumber)
            {
                bestTime.StringToImages(level.bestTime);
            }
        }
    }
}
