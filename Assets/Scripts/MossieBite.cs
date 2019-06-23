using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossieBite : MonoBehaviour {

    private Animator _animator;

    [SerializeField] private float biteTimer = 0f;
    private float timer;

    // Use this for initialization
    void Start()
    {
        _animator = GetComponent<Animator>();
        timer = 0;
        StartCoroutine(BiteCounter());
    }

    IEnumerator BiteCounter()
    {
        yield return new WaitForSeconds(1f);
        timer++;

        if (timer == biteTimer)
        {
            _animator.SetTrigger("Bite");
            timer = 0;
        }

        StartCoroutine(BiteCounter());
    }
}
