using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class MoveAnimation : MonoBehaviour
{
    private readonly int _isRun = Animator.StringToHash("isRun");
    [SerializeField] private Animator _animator;
    
    private bool IsRun => Input.GetAxisRaw("Horizontal") < -0.01f || Input.GetAxisRaw("Horizontal") > 0.01f;

    private void OnValidate()
    {
        if (_animator == null) 
            Debug.LogWarning("Animator not found", this);
    }
    
    
    private void Update()
    {
        _animator.SetBool(_isRun, IsRun);
        MirrorSprite();
    }

    private void MirrorSprite()
    {
        if (!IsRun)
            return;
        
        Vector3 scale = transform.localScale;
        var sign = Mathf.Sign(Input.GetAxisRaw("Horizontal"));
        scale = new Vector3(Mathf.Abs(scale.x) * sign, scale.y, scale.z);

        transform.localScale = scale;
    }
}
