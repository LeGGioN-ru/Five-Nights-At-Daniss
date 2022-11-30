using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using DG.Tweening;

public class SpeedTricks : DialogueEvent
{
    [SerializeField] private PostProcessVolume _postProcess;
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private float _durationSpeedUp;

    private float _passedTime;

    public override void Happen()
    {
        StartCoroutine(SmoothWeight());
        _particleSystem.Play();
    }

    private IEnumerator SmoothWeight()
    {
        while (_passedTime < _durationSpeedUp)
        {
            _passedTime += Time.deltaTime;
            _postProcess.weight = Mathf.Lerp(0, 1, _passedTime / _durationSpeedUp);
            yield return null;
        }
    }
}
