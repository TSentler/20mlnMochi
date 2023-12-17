using System.Collections;
using UnityEngine;

public class PlayerHealth : CharacterHealth
{
    private const float PlayerDamageDelay = 1f;

    private readonly int HitName = Animator.StringToHash("isHit");
    private readonly int DeadName = Animator.StringToHash("isDead");

    [SerializeField] private Animator _animator;
    
    private LifeBar _lifeBar;
    private bool _canBeDamaged = true;
    public bool CanBeDamaged => _canBeDamaged;
    public override bool IsDead => _health <= 0;

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
        
        StartCoroutine(DamageCooldown());
    }

    IEnumerator DamageCooldown()
    {
        _canBeDamaged = false;
        yield return new WaitForSecondsRealtime(PlayerDamageDelay);
        _canBeDamaged = true;
    }
}