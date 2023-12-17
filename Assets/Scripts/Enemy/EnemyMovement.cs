using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Movement _movement;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private EnemyHealth _enemyHealth;


    Vector2 _movementDirection = new Vector2(0f, 0f);
    float _angle;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (CanMove())
        {
            _movement.UnPause();
        }
        else
        {
            _movement.Pause();
        }

        _movement.Move(new Vector2(-1f, 0f));

        
        //_movement.Move(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));
        //_moveAnimation.Move(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));

    }

    private bool CanMove()
    {
        return (_enemyHealth.CanBeDamaged) && !(_enemyHealth.IsDead);
    }

    /*
    private bool CanMove()
    {
        return (_playerHealth.CanBeDamaged) && !(_playerHealth.IsDead);
    }
    */

    //_angle += _enemyRunSpeed;
    //_angle = Mathf.Repeat(_angle, 360f);
    //_movementDirection.x = Mathf.Sin(_angle);
}
