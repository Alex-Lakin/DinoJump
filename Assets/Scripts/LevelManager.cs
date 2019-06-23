using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

[Serializable] public class CompletedLevels
{
    public int levelUnlocked { get; set; }
    public string bestTime { get; set; }
}

public class LevelManager : MonoBehaviour {

    [SerializeField] float splashScreenTime;

    [HideInInspector] public float gameVolume;
    [HideInInspector] public int fullScreen;

    [HideInInspector] public List<CompletedLevels> completedLevelList;

    private string DATA_Path = "/SaveData.dat";

    // Use this for initialization
    void Start ()
    {
        DontDestroyOnLoad(this.gameObject);

        gameVolume = PlayerPrefs.GetFloat("Game Volume");
        SetVolume(gameVolume);

        fullScreen = PlayerPrefs.GetInt("Full screen");
        if (fullScreen == 1) { SetFullScreen(true); } else { SetFullScreen(false); }

        completedLevelList = new List<CompletedLevels>();

        LoadProgress();

        StartCoroutine(SplashScreenTimer());
    }

    private void Update()
    {
        //foreach (CompletedLevels level in completedLevelList)
        //{
            //Debug.Log("Level: " + level.levelUnlocked + ".   Best timer: " + level.bestTime);
        //} 
    }

    IEnumerator SplashScreenTimer() {
        yield return new WaitForSecondsRealtime(splashScreenTime);
        GoToMainMenu();
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("1aMainMenu");
    }

    public void GoToOptions()
    {
        SceneManager.LoadScene("1bOptions");
    }

    public void SetVolume(float vol)
    {
        AudioListener.volume = vol;
        gameVolume = vol;
        PlayerPrefs.SetFloat("Game Volume", gameVolume);
    }

    public void SetFullScreen(bool fullScrn)
    {
        Screen.fullScreen = fullScrn;
        if (fullScrn == true)
        {
            fullScreen = 1;
        } else
        {
            fullScreen = 0;
        }
        PlayerPrefs.SetInt("Full screen", fullScreen);
    }

    public void GoToLevelSelect()
    {
        SceneManager.LoadScene("1cLevelSelect");
    }

    public void SaveProgress()
    {
        FileStream file = null;

        try {
            BinaryFormatter bf = new BinaryFormatter();

            file = File.Create(Application.persistentDataPath + DATA_Path);

            bf.Serialize(file, completedLevelList);

        } catch (Exception e) {
            if (e != null) {
                //handle exception
            }
        } finally {
            if (file != null) {
                file.Close();
            }
        }
    }

    public void LoadProgress()
    {
        FileStream file = null;

        try {
            BinaryFormatter bf = new BinaryFormatter();

            file = File.Open(Application.persistentDataPath + DATA_Path, FileMode.Open);

            completedLevelList = bf.Deserialize(file) as List<CompletedLevels>;

        } catch (Exception e) {
            completedLevelList.Add(new CompletedLevels { levelUnlocked = 1, bestTime = "99999999" });
        } finally {
            if (file != null) {
                file.Close();
            }
        }
    }

    public void GoToLevel(float levelNumber)
    {
        SceneManager.LoadScene("2aLevel" + levelNumber);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
