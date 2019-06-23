using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class NumberStringToImages : MonoBehaviour {

    [SerializeField] private Sprite[] numberImages;
    [SerializeField] private GameObject[] imageObjects;
    private Image[] imageComponents;

	// Use this for initialization
	void Start () {
        imageComponents = new Image[imageObjects.Length];
        for (int i= 0; i < imageObjects.Length; i++) {
            imageComponents[i] = imageObjects[i].GetComponent<Image>();
        }
	}

    public void StringToImages(string numberstring)
    {
        if (numberstring == "99999999") { numberstring = "000000"; }
        string[] digitsAsString = new string[numberstring.Length];
        int[] digitsAsInts = new int[digitsAsString.Length];

        for (int i = 0; i < numberstring.Length; i++)
        {
            digitsAsString[i] = numberstring[i].ToString();
            int.TryParse(digitsAsString[i], out digitsAsInts[i]);
            imageComponents[i].sprite = numberImages[digitsAsInts[i]];
        }
    }
}
