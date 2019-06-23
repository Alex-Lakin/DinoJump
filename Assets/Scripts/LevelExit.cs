using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelExit : MonoBehaviour {

    private LevelManager levelManager;
    private LevelTimer levelTimer;

    [SerializeField] private int levelNumber;

    // Use this for initialization
    void Start () {
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        levelTimer = GameObject.Find("LevelTimer").GetComponent<LevelTimer>();

        int lastCompletedLevel = levelManager.completedLevelList[levelManager.completedLevelList.Count - 1].levelUnlocked;
        Debug.Log(lastCompletedLevel);
        if (lastCompletedLevel == levelNumber)
        {
            levelTimer.DestroyVisableTimer();
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LevelComplete()
    {
        string levelTime = levelTimer.SendEndTime();
        string bestTime = levelManager.completedLevelList[levelNumber - 1].bestTime;

        int bestTimeint;
        int levelTimeint;

        int.TryParse(levelTime, out levelTimeint);
        int.TryParse(bestTime, out bestTimeint);

        if (levelTimeint <= bestTimeint) {
            levelManager.completedLevelList[levelNumber - 1].bestTime = levelTime;
            levelManager.SaveProgress();
        }
        
        foreach (CompletedLevels level in levelManager.completedLevelList)
        {
            if (level.levelUnlocked == levelNumber + 1)
            {
                levelManager.GoToLevelSelect();
                return;
            }
            
        }
        levelManager.completedLevelList.Add(new CompletedLevels { levelUnlocked = levelNumber + 1, bestTime = "99999999" });
        levelManager.SaveProgress();
        levelManager.GoToLevelSelect();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            LevelComplete();
        }
    }
}
