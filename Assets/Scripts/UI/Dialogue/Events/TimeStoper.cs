using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using DG.Tweening;

public class TimeStoper : DialogueEvent
{
    [SerializeField] private Animator _carAnimator;
    [SerializeField] private Animator _truckAnimator;
    [SerializeField] private float _newSpeed;
    [SerializeField] private PostProcessProfile _profile;
    [SerializeField] private PostProcessVolume _postProcess;
    [SerializeField] private float _durationSpeedDown;
    [SerializeField] private AudioSource _soundDrive;
    [SerializeField] private float _newPitch;
    [SerializeField] private float _durationPitchChange;

    private float _passedTime;

    public override void Happen()
    {
        _carAnimator.speed = _newSpeed;
        _truckAnimator.speed = _newSpeed;
        _postProcess.weight = 0;
        _postProcess.profile = _profile;
        _soundDrive.DOPitch(_newPitch, _durationPitchChange);
        StartCoroutine(SmoothWeight());
    }

    private IEnumerator SmoothWeight()
    {
        while (_passedTime < _durationSpeedDown)
        {
            _passedTime += Time.deltaTime;
            _postProcess.weight = Mathf.Lerp(0, 1, _passedTime / _durationSpeedDown);
            yield return null;
        }
    }
}
