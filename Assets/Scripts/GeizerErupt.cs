using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeizerErupt : MonoBehaviour {

    private Animator _animator;
    private AudioSource _audioSource;
    private PauseController _pauseController;

    [SerializeField] private float eruptTimerUp = 0f;
    [SerializeField] private float eruptTimerDown = 0f;
    [SerializeField] private AudioClip upSound;
    [SerializeField] private AudioClip downSound;
    private float timer;

    // Use this for initialization
    void Start()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        _pauseController = GetComponent<PauseController>();
        timer = 0;
        _audioSource.PlayOneShot(downSound, 1f);
    }

    private void Update()
    {
        if (_pauseController.paused == false) {
            ErruptCounter();
        }
    }

    private void ErruptCounter() {
        timer += 1 * Time.deltaTime;
        if (_animator.GetBool("Erupting") == false && timer >= eruptTimerUp && timer < eruptTimerDown)
        {
            _animator.SetBool("Erupting", true);
            _audioSource.Stop();
            _audioSource.PlayOneShot(upSound, 1f);
        } else if (timer >= eruptTimerDown)
        {
            _animator.SetBool("Erupting", false);
            _audioSource.Stop();
            _audioSource.PlayOneShot(downSound, 1f);
            timer = 0;
        }
    }
}
