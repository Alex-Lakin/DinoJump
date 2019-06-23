using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class VolumeSlider : MonoBehaviour {

    private Image sliderImage;
    private LevelManager levelManager;

    [SerializeField] private Sprite[] volumeSprites;

	// Use this for initialization
	void Start () {
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        sliderImage = GetComponent<Image>();
        int vol = Mathf.RoundToInt(levelManager.gameVolume * 10);
        sliderImage.sprite = volumeSprites[vol];
	}


	
    public void IncreaseVolume()
    {
        float vol = levelManager.gameVolume;
        if (vol < 1)
        {
            vol += 0.1f;
            levelManager.SetVolume(vol);
            sliderImage.sprite = volumeSprites[Mathf.RoundToInt(levelManager.gameVolume * 10)];
        } else if (vol > 1) { vol = 1; }
    }

    public void DecreaseVolume()
    {
        float vol = levelManager.gameVolume;
        if (vol > 0)
        {
            vol -= 0.1f;
            levelManager.SetVolume(vol);
            sliderImage.sprite = volumeSprites[Mathf.RoundToInt(levelManager.gameVolume * 10)];
        } else if (vol < 0) { vol = 0; }
    }
}
