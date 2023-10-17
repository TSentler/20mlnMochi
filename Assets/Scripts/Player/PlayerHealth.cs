using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private const float DestroyDelay = 2f;

    private readonly int HitName = Animator.StringToHash("isHit");
    private readonly int DeadName = Animator.StringToHash("isDead");

    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private int _health;
    [SerializeField] private float _thrust;


    private bool IsDead => _health <= 0;

    public void PlayerDamage(Transform attacker)
    {
        if (IsDead)
            return;

        AddThrust(attacker);
        _animator.SetTrigger(HitName);
        _health -= 0;

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
        Debug.Log("я получаю ускорение");

        // загуглить корутины для написания кулдауна
    }
}