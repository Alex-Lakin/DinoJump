using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrackNeckandTail : MonoBehaviour {

    private Animator _animator;

    [SerializeField] private float neckTimerUp = 0f;
    [SerializeField] private float neckTimerDown = 0f;
    private float timer;

    // Use this for initialization
    void Start()
    {
        _animator = GetComponent<Animator>();
        timer = 0;
        StartCoroutine(MoveCounter());
    }

    IEnumerator MoveCounter()
    {
        yield return new WaitForSeconds(1f);
        timer++;

        if (timer == neckTimerUp)
        {
            _animator.SetBool("Raising", true);
        }
        else if (timer == neckTimerDown)
        {
            _animator.SetBool("Raising", false);
            timer = 0;
        }

        StartCoroutine(MoveCounter());
    }
}
