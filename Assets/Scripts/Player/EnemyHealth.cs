using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : CharacterHealth
{
    private const float DestroyDelay = 2f;

    private readonly int DamagedName = Animator.StringToHash("Damaged");
    private readonly int DeadName = Animator.StringToHash("Dead");

    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private int _enemyHealth;

    private bool IsDead => _enemyHealth <= 0;

    public void Damage(Transform attacker)
    {
        if (IsDead)
            return;

        //AddThrust(attacker);
        OnDamaged.Invoke(attacker);
        _animator.SetTrigger(DamagedName);
        _enemyHealth -= 1;

        if (IsDead)
        {
            _animator.SetTrigger(DeadName);
            _rb.Sleep();
            //Destroy(_rb, DestroyDelay);
        }
    }
}
