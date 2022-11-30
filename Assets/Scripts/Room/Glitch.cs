using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Glitch : MonoBehaviour
{
    [SerializeField] private RoomRenderer[] _roomRenderers;
    [SerializeField] private RawImage _rawImage;
    [SerializeField] private float _glitchDuration;
    [SerializeField] private AudioSource _sound;

    private void OnEnable()
    {
        foreach (var renderer in _roomRenderers)
        {
            renderer.ImageChanged += OnImageChange;
        }
    }

    private void OnDisable()
    {
        foreach (var renderer in _roomRenderers)
        {
            renderer.ImageChanged -= OnImageChange;
        }
    }

    private void OnImageChange()
    {
        _sound.Play();
        Sequence sequence = DOTween.Sequence();
        sequence.Append(_rawImage.DOFade(1, _glitchDuration));
        sequence.Append(_rawImage.DOFade(0, _glitchDuration));
    }
}
