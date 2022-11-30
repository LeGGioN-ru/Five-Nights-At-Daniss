using UnityEngine;
using DG.Tweening;

public class AnimationSpeedUper : DialogueEvent
{
    [SerializeField] private Animator _animator;
    [SerializeField] private float _newSpeed;
    [SerializeField] private AudioSource _driveSound;
    [SerializeField] private float _addPitch;
    [SerializeField] private float _duration = 0.5f;

    public override void Happen()
    {
        _driveSound.DOPitch(_driveSound.pitch + _addPitch, _duration);
        _animator.speed = _newSpeed;
    }
}
