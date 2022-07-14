using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;

    private float _horizontal;
    private float _vertical;

    public float runSpeed = 10.0f;
    
    // Update is called once per frame
    void Update()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        _vertical = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector2(_horizontal * runSpeed, _vertical * runSpeed);   
    }
}
