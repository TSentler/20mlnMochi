using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private const float DestroyDelay = 2f;

    private readonly int DamagedName = Animator.StringToHash("Damaged");
    private readonly int DeadName = Animator.StringToHash("Dead");

    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private int _enemyHealth;
    [SerializeField] private float _thrust;


    private bool IsDead => _enemyHealth <= 0;

    public void Damage(Transform attacker)
    {
        if (IsDead)
            return;

        AddThrust(attacker);
        _animator.SetTrigger(DamagedName);
        _enemyHealth -= 1;

        if (IsDead)
        {
            _animator.SetTrigger(DeadName);
            Destroy(_rb, DestroyDelay);
        }
    }


    private void AddThrust(Transform attacker)
    {
        float sign = Mathf.Sign(transform.position.x - attacker.position.x);
        Vector2 direction = new Vector2(sign, 1f);
        _rb.AddForce(direction * _thrust, ForceMode2D.Impulse);
    }
}
