using System;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    private float _horizontal;
    private float _vertical;

    private Rigidbody2D _rb;
    [SerializeField] private float _runSpeed = 10.0f;
    
    public float RunSpeed
    {
        get => _runSpeed;
        set => _runSpeed = value;
    }

    private void Awake()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector2(_horizontal * _runSpeed * Time.deltaTime, _rb.velocity.y )  ;   
    }

}


