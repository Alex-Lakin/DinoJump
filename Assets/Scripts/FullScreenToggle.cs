using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class FullScreenToggle : MonoBehaviour {

    private Image fullScreenImage;
    private LevelManager levelManager;

    [SerializeField] private Sprite[] fullScreenSprites;

    private int isFullScreen;

    // Use this for initialization
    void Start()
    {
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        fullScreenImage = GetComponent<Image>();

        isFullScreen = levelManager.fullScreen;
        fullScreenImage.sprite = fullScreenSprites[isFullScreen];
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void ToggleFullScreen()
    {
        if (isFullScreen == 1)
        {
            isFullScreen = 0;
            levelManager.SetFullScreen(false);
        } else if (isFullScreen == 0)
        {
            isFullScreen = 1;
            levelManager.SetFullScreen(true);
        }
        fullScreenImage.sprite = fullScreenSprites[isFullScreen];
    }
}
