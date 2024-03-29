using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class MoveAnimation : MonoBehaviour
{
    private readonly int _isRun = Animator.StringToHash("IsRun");
    private float _horizontal;

    [SerializeField] private Animator _animator;
    [SerializeField] private CharacterHealth _characterHealth;

    private bool IsRun => _horizontal < -0.01f || _horizontal > 0.01f;

    private void OnValidate()
    {
        if (_animator == null) 
            Debug.LogWarning("Animator not found", this);
    }
    
    public void MirrorSprite()
    {
        if (!IsRun || _characterHealth.IsDead) 
            return;
        
        Vector3 scale = transform.localScale;
        var sign = Mathf.Sign(_horizontal);
        scale = new Vector3(Mathf.Abs(scale.x) * sign, scale.y, scale.z);

        transform.localScale = scale;
    }
    
    public void Move(Vector2 direction)
    {
        _horizontal = direction.x;
        _animator.SetBool(_isRun, IsRun);
        MirrorSprite();
    }
}
