using UnityEngine;
using UnityEngine.Events;

public abstract class CharacterHealth : MonoBehaviour
{
    public UnityEvent<Transform> OnDamaged = new();

    [SerializeField] public int _health;
    public virtual bool IsDead { get; }
}
