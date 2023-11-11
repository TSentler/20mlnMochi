using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    //[SerializeField] private ColliderCollisionChecker _colliderCollisionChecker;
    [SerializeField] private LayerMask _layerMask;
    private BoxCollider2D _boxCollider2D;

    private void Start()
    {
        _boxCollider2D = gameObject.GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        ColliderCollisionCheck();
    }

    private void ColliderCollisionCheck()
    {
        Collider2D targetCollider = Physics2D.OverlapBox(
                    (Vector2)(transform.position) + _boxCollider2D.offset * transform.lossyScale, _boxCollider2D.size * transform.lossyScale, 0f, _layerMask);
        CollectItem(targetCollider);
    }

    private void CollectItem(Collider2D targetCollider)
    {
        if (targetCollider == null)
            return;

        gameObject.SetActive(false);
    }

}
