using UnityEngine;

public abstract class RandomEvent : MonoBehaviour
{
    [SerializeField] private float _chance;
    [SerializeField] private bool _isCanReply;

    public float Chance => _chance;
    public bool IsCanReply => _isCanReply;

    public abstract void Happen();
}
