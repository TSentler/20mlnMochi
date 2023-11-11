using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private const float EnemyDamageDelay = 0.5f;

    private readonly int AttackName = Animator.StringToHash("IsAttack");
    
    public KeyCode Key;
    
    [SerializeField] private Animator _animator;
    [SerializeField] private BoxCollider2D _boxCollider2D;
    [SerializeField] private LayerMask _layerMask;
    private bool _canBeDamaged = true;

    private void OnValidate()
    {
        if (_animator == null)
            Debug.LogWarning("Animator not found", this);
    }

    private void Update()
    {
        if (Input.GetKeyDown(Key))
        {
            _animator.SetTrigger(AttackName);
        }
    }

    private void AttackEnemy()
    {
        Collider2D enemyCollider = Physics2D.OverlapBox(
                        _boxCollider2D.transform.position, _boxCollider2D.size, 0f, _layerMask);
        AttackEnemy(enemyCollider);
    }

    private void AttackEnemy(Collider2D enemyCollider)
    {
        if (_canBeDamaged == false)
            return;

        if (enemyCollider == null) 
            return;

        EnemyHealth enemy = enemyCollider.GetComponent<EnemyHealth>();
        if (enemy == null)
            return;

        enemy.Damage(transform);

        _canBeDamaged = false;
        StartCoroutine(DamageCooldown());
    }

    IEnumerator DamageCooldown()
    {
        yield return new WaitForSecondsRealtime(EnemyDamageDelay);
        _canBeDamaged = true;
    }
}
