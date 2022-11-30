using System.Collections;
using DG.Tweening;
using UnityEngine;

public class Lightning : RandomEvent
{
    [SerializeField] private Light _thunder;
    [SerializeField] private AudioSource _sound;
    [SerializeField] private float _thunderTimeEnd;
    [SerializeField] private float _thunderTimeStart;
    [SerializeField] private float _targetIntensivity;

    private Sequence _sequence;

    public override void Happen()
    {
        _thunder.enabled = true;
        _sound.Play();
        _sequence = DOTween.Sequence();
        _sequence.Append(_thunder.DOIntensity(_targetIntensivity, _thunderTimeStart));
        _sequence.Append(_thunder.DOIntensity(0, _thunderTimeEnd));
        _sequence.OnComplete(() => _thunder.enabled = false);
    }
}
