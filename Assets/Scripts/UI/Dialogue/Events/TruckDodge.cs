using UnityEngine;
using DG.Tweening;

public class TruckDodge : DialogueEvent
{
    [SerializeField] private TruckMover _truckMover;
    [SerializeField] private Animator _animatorCar;
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private AudioSource _soundDrive;
    [SerializeField] private float _durationSoundDriveEnable;

    public override void Happen()
    {
        Destroy(_particleSystem.gameObject);
        _soundDrive.DOPitch(1, _durationSoundDriveEnable);
        _truckMover.Happen();
        _animatorCar.Play(CarController.Animations.DodgeTruck);
    }
}
