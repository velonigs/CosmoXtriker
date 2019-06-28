using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowAnimator : MonoBehaviour {

    private Animator _animator;

    void Start() {
        _animator = GetComponent<Animator>();
    }

    public void FadeIn() {
        _animator.SetTrigger("FadeInTrigger");
    }
    
    public void FadeOut() {
        _animator.SetTrigger("FadeOutTrigger");
    }

    public bool IsCompletedFadeOut() {
        var state = _animator.GetCurrentAnimatorStateInfo(0);
        return state.normalizedTime < 1.0f ? false : true;
    }
}