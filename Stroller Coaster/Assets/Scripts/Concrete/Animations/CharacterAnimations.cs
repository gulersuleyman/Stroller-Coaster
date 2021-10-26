using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimations : MonoBehaviour
{
    Animator _animator;


    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
    }
    public void RunningAnimation(bool isRunning)
    {
        if (isRunning == _animator.GetBool("isRunning")) return;

        _animator.SetBool("isRunning", isRunning);
    }

    public void FallingAnimation(bool isFalling)
    {
        if (isFalling == _animator.GetBool("isFalling")) return;

        _animator.SetBool("isFalling", isFalling);
    }
    public void FunAnimation(bool isFun)
    {
        if (isFun == _animator.GetBool("isFun")) return;

        _animator.SetBool("isFun", isFun);
    }
    public void RightAnimation(bool isRight)
    {
        if (isRight == _animator.GetBool("isRight")) return;

        _animator.SetBool("isRight", isRight);
    }
    public void LeftAnimation(bool isLeft)
    {
        if (isLeft == _animator.GetBool("isLeft")) return;

        _animator.SetBool("isLeft", isLeft);
    }
}
