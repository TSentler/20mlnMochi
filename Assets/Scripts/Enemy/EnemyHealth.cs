using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : CharacterHealth
{
    private const float DamageDelay = 1f;
    //private const float DestroyDelay = 2f;

    private readonly int DamagedName = Animator.StringToHash("Damaged");
    private readonly int DeadName = Animator.StringToHash("Dead");

    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody2D _rb;

    private bool _canBeDamaged = true;

    public bool CanBeDamaged => _canBeDamaged;
    public override bool IsDead => _health <= 0;

    public void Damage(Transform attacker)
    {
        if (IsDead) 
            return;

        _health -= 1;

        if (IsDead)
        {
            _animator.SetTrigger(DeadName);
            _rb.simulated = false;
        }

        OnDamaged.Invoke(attacker);
        _animator.SetTrigger(DamagedName);
        StartCoroutine(DamageCooldown());
    }

    IEnumerator DamageCooldown()
    {
        _canBeDamaged = false;
        yield return new WaitForSecondsRealtime(DamageDelay);
        _canBeDamaged = true;
    }
}
