using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Movement _movement;

    private void Move()
    {
        _movement.RunSpeed = 11f;
    }
}
