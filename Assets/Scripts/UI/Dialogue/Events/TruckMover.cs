using UnityEngine;
using DG.Tweening;

public class TruckMover : DialogueEvent
{
    [SerializeField] private Truck _truck;
    [SerializeField] private Transform _point;
    [SerializeField] private float _duration;

    public override void Happen()
    {
        _truck.transform.DOMove(_point.position, _duration);
    }
}
