using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private const float DestroyDelay = 2f;

    private readonly int HitName = Animator.StringToHash("isHit");
    private readonly int DeadName = Animator.StringToHash("isDead");

    [SerializeField] private Animator _animator;
    [SerializeField] private Collider2D _collider2D;
    [SerializeField] private int _playerHealth;
    [SerializeField] private float _thrust;


    private bool IsDead => _playerHealth <= 0;

    public void PlayerDamage(Transform attacker)
    {
        if (IsDead)
            return;

        AddThrust(attacker);
        _animator.SetTrigger(HitName);
        _playerHealth -= 1;

        if (IsDead)
        {
            _animator.SetTrigger(DeadName);
        }
    }


    private void AddThrust(Transform attacker)
    {
        float sign = Mathf.Sign(transform.position.x - attacker.position.x);
        Vector2 direction = new Vector2(sign, 1f);
        _rb.AddForce(direction * _thrust, ForceMode2D.Impulse);
    }
}



    Collider2D enemyCollider = Physics2D.OverlapBox(
        _boxCollider2D.transform.position, _boxCollider2D.size, 0f, _layerMask);
    PlayerDamage(Transform attacker);

    