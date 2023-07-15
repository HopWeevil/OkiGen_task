using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void PickUpFood()
    {
        _animator.SetTrigger("PickUpFood");
    }

    public void DropFood()
    {
        _animator.ResetTrigger("PickUpFood");
        _animator.SetTrigger("DropFood");
    }

    public void Dance()
    {
        _animator.SetTrigger("Dance");
    }

    public void Idle()
    {
        _animator.SetTrigger("Idle");
    }
}
