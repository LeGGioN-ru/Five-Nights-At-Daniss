using UnityEngine;

public abstract class RandomEvent : MonoBehaviour
{
    [SerializeField] private float _chance;

    public float Chance => _chance;

    public abstract void Happen();
}
