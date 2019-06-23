using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class BackgroundGlow : MonoBehaviour {

    private EventSystem eventSystem;

    private Image glowEffect;
    private bool glowEffectIsActive = false;

	// Use this for initialization
	void Start () {
        glowEffect = GetComponent<Image>();
        eventSystem = EventSystem.current;
	}
	
	// Update is called once per frame
	void Update () {
		if (eventSystem.currentSelectedGameObject == transform.parent.gameObject && glowEffectIsActive == false)
        {
            GlowEffectIsActive(true);
        } else if (eventSystem.currentSelectedGameObject != transform.parent.gameObject && glowEffectIsActive == true)
        {
            GlowEffectIsActive(false);
        }
	}

    private void GlowEffectIsActive(bool activate)
    {
        var tempColor = glowEffect.color;
        if (activate)
        {
            tempColor.a = 1f;
            glowEffectIsActive = true;
        } else {
            tempColor.a = 0f;
            glowEffectIsActive = false;
        }
        glowEffect.color = tempColor;
    }
}
