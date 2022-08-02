using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class GroundChecker : MonoBehaviour
{
    private BoxCollider2D _ground;
    private List<Collider2D> _colliders = new List<Collider2D>();
    [SerializeField] private ContactFilter2D _contactFilter;
    
    
    private void Awake()
    {
        _ground = GetComponent<BoxCollider2D>();
    }

    public bool IsGround()
    {
        _colliders.Clear();
        Physics2D.OverlapCollider(_ground, _contactFilter, _colliders);
        return _colliders.Count != 0;
    }
}


