using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Jump : MonoBehaviour
{
    private bool _isJump;
    private Rigidbody2D _rb;
    [SerializeField] private float _jumpSpeed = 4.0f;
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private PlayerHealth _playerHealth;

    private void OnValidate()
    {
        if (_groundChecker == null) 
            Debug.LogWarning("GroundChecker not found", this);
    }
    
    private void Awake()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _isJump = Input.GetButtonDown("Jump");
        if (_isJump && _groundChecker.IsGround() && !_playerHealth.IsDead)  
        {
            _rb.AddForce(Vector2.up * _jumpSpeed, ForceMode2D.Impulse);
        }
    }

}
    