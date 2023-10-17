using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Serialization;
using static UnityEngine.EventSystems.EventTrigger;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    private float _horizontal;

    private Vector3 worldCenter;
    private Vector3 worldHalfExtents;

    private Rigidbody2D _rb;
    [SerializeField] private float _runSpeed = 10.0f;
    [SerializeField] private BoxCollider2D _boxCollider2D;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private PlayerHealth _playerHealth;


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
        Collider2D enemyCollider = Physics2D.OverlapBox( 
            (Vector2)(transform.position) + _boxCollider2D.offset * transform.lossyScale, _boxCollider2D.size * transform.lossyScale, 0f, _layerMask);
        AttackPlayer(enemyCollider);
    }

    private void AttackPlayer(Collider2D targetCollider)
    {
        if (targetCollider == null)
            return;

        _playerHealth.PlayerDamage(targetCollider.transform);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Check that it is being run in Play Mode, so it doesn't try to draw this in Editor mode
        if (true)
            //Draw a cube where the OverlapBox is (positioned where your GameObject is as well as a size)
            Gizmos.DrawWireCube((Vector2)(transform.position) + _boxCollider2D.offset * transform.lossyScale, _boxCollider2D.size * transform.lossyScale);
    }
}


