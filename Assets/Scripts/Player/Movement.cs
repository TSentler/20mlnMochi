using System;
using System.Collections;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Serialization;
using static UnityEngine.EventSystems.EventTrigger;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    private float _horizontal;
    private const float PlayerDamageDelay = 1f;

    private bool canThrust = true;

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
        if ((canThrust) && !(_playerHealth.IsDead))
            _rb.velocity = new Vector2(_horizontal * _runSpeed * Time.deltaTime, _rb.velocity.y);   

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
        if (!canThrust)
            return;

        canThrust = false;
        _playerHealth.PlayerDamage(targetCollider.transform);
        StartCoroutine(DamageCooldown());
    }

    IEnumerator DamageCooldown()
    {
        yield return new WaitForSecondsRealtime(PlayerDamageDelay);
        canThrust = true;
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


