using UnityEngine;
using UnityEngine.Events;

public abstract class CharacterHealth : MonoBehaviour
{
    public UnityEvent<Transform> OnDamaged = new();
}
