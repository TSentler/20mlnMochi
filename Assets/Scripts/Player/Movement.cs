using UnityEngine;
using UnityEngine.Serialization;

public class Movement : MonoBehaviour
{
    private float _horizontal;
    private float _vertical;

    [SerializeField] private Rigidbody2D _rb;
    
    [SerializeField] private float _runSpeed = 10.0f;

    public float RunSpeed
    {
        get => _runSpeed;
        set => _runSpeed = value;
    }

    // Update is called once per frame
    void Update()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        _vertical = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector2(_horizontal * _runSpeed, _vertical * _runSpeed);   
    }

}


