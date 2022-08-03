using System;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    private float _horizontal;

    private Rigidbody2D _rb;
    [SerializeField] private float _runSpeed = 10.0f;
    
    private void Awake()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector2(_horizontal * _runSpeed * Time.deltaTime, _rb.velocity.y );   
    }
    
    public void Move(Vector2 direction)
    {
        _horizontal = direction.x;
    }

}


