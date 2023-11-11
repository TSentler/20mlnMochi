using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class ColliderCollisionChecker : MonoBehaviour
{

    [SerializeField] private LayerMask _layerMask;
    private BoxCollider2D _boxCollider2D;
    private PlayerHealth _playerHealth;
   

    private void Awake()
    {
        _playerHealth = FindObjectOfType<PlayerHealth>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ColliderCollisionCheck();
    }

    private void ColliderCollisionCheck()
    {
        Collider2D enemyCollider = Physics2D.OverlapBox(
                    (Vector2)(transform.position) + _boxCollider2D.offset * transform.lossyScale, _boxCollider2D.size * transform.lossyScale, 0f, _layerMask);
        AttackPlayer(enemyCollider);
    }

    private void AttackPlayer(Collider2D targetCollider)
    {
        if (targetCollider == null)
            return;
        if (!_playerHealth.CanBeDamaged)
            return;

        _playerHealth.PlayerDamage(targetCollider.transform);  
    }

    /*
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Check that it is being run in Play Mode, so it doesn't try to draw this in Editor mode
        if (true)
            //Draw a cube where the OverlapBox is (positioned where your GameObject is as well as a size)
            Gizmos.DrawWireCube((Vector2)(transform.position) + _boxCollider2D.offset * transform.lossyScale, _boxCollider2D.size * transform.lossyScale);
    }*/
}
