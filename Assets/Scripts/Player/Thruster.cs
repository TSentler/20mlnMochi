using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D), typeof(CharacterHealth), typeof(Movement))]
public class Thruster : MonoBehaviour
{
    [SerializeField] private float _thrust;
    [SerializeField] private Movement _movement;
    private CharacterHealth _characterHealth;
    private Rigidbody2D _rb;

    private void Awake()
    {
        _characterHealth = gameObject.GetComponent<CharacterHealth>();
        _rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _characterHealth.OnDamaged.AddListener(AddThrust);
    }

    private void AddThrust(Transform attacker)
    {
        float sign = Mathf.Sign(transform.position.x - attacker.position.x);
        Vector2 direction = new Vector2(sign, 1f);
        _rb.velocity = Vector2.zero;
        _rb.AddForce(direction * _thrust, ForceMode2D.Impulse);
    }
}
