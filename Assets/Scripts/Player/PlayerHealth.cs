using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.Events;


public class PlayerHealth : CharacterHealth
{
    private const float PlayerDamageDelay = 1f;

    private readonly int HitName = Animator.StringToHash("isHit");
    private readonly int DeadName = Animator.StringToHash("isDead");

    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] public int _health;
    
    private LifeBar _lifeBar;
    private bool _canBeDamaged = true;
    public bool CanBeDamaged => _canBeDamaged;
    public bool IsDead => _health <= 0;

    private void Awake()
    {
        _lifeBar = FindObjectOfType<LifeBar>();
    }

    public void PlayerDamage(Transform attacker)
    {
        _health -= 1;
        _lifeBar.Damage();
        OnDamaged.Invoke(attacker);

        if (IsDead)
        {
            _animator.SetTrigger(DeadName);
        } else
        {
            _animator.SetTrigger(HitName);
        }
        
        _canBeDamaged = false;
        StartCoroutine(DamageCooldown());
    }
    IEnumerator DamageCooldown()
    {
        yield return new WaitForSecondsRealtime(PlayerDamageDelay);
        _canBeDamaged = true;
    }
}