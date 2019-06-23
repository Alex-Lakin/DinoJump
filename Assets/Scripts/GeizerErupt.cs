using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeizerErupt : MonoBehaviour {

    private Animator _animator;
    private PauseController _pauseController;

    [SerializeField] private float eruptTimerUp = 0f;
    [SerializeField] private float eruptTimerDown = 0f;
    private float timer;

    // Use this for initialization
    void Start()
    {
        _animator = GetComponent<Animator>();
        _pauseController = GetComponent<PauseController>();
        timer = 0;
    }

    private void Update()
    {
        if (_pauseController.paused == false) {
            ErruptCounter();
        }
    }

    private void ErruptCounter() {
        timer++;
        if (timer == eruptTimerUp)
        {
            _animator.SetBool("Erupting", true);
        } else if (timer == eruptTimerDown)
        {
            _animator.SetBool("Erupting", false);
            timer = 0;
        }
    }
}
