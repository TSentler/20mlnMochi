using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    public bool _canMove = true;
    [SerializeField] private float _runSpeed = 10.0f;
    private Rigidbody2D _rb;
    private float _horizontal;

    private void Awake()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (_canMove)
            _rb.velocity = new Vector2(_horizontal * _runSpeed * Time.deltaTime, _rb.velocity.y);
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


