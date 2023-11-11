using System;
using System.Collections;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Serialization;
using static UnityEngine.EventSystems.EventTrigger;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    [SerializeField] private float _runSpeed = 10.0f;
    private Rigidbody2D _rb;
    private float _horizontal;
    private bool _canMove = true;

    private void Awake()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (CanMove())
            _rb.velocity = new Vector2(_horizontal * _runSpeed * Time.deltaTime, _rb.velocity.y);
    }

    private bool CanMove()
    {
        return _canMove;
    }

    public void Pause()
    {
        _canMove = false;
    }

    public void UnPause()
    {
        _canMove = true;
    }

    public void Move(Vector2 direction)
    {
        _horizontal = direction.x; 
    }
}


