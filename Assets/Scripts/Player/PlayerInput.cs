using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Movement _movement;
    [SerializeField] private MoveAnimation _moveAnimation;
    [SerializeField] private PlayerHealth _playerHealth;


    private void OnValidate()
    {
        if (_movement == null) 
            Debug.LogWarning("Movement not found", this);
        if (_moveAnimation == null) 
            Debug.LogWarning("MoveAnimation not found", this);
    }

    private void Update()
    {
        if (CanMove())
        {
            _movement.UnPause();
        }
        else
        {
            _movement.Pause();
        }
            _movement.Move(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));
            _moveAnimation.Move(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));
    }
    private bool CanMove()
    {
        return (_playerHealth.CanBeDamaged) && !(_playerHealth.IsDead);
    }
}
