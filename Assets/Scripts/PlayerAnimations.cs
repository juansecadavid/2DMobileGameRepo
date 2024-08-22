using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] private Movement _movement;
    [SerializeField] private Animator _animator;
    private void Update()
    {
        _animator.SetFloat("Blend", _movement.MovementDirection);
    }
}
