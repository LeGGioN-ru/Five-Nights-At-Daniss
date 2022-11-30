using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class BlackScreenDestroyer : DialogueEvent
{
    [SerializeField] private Image _blackScreen;
    [SerializeField] private float _duration;
    [SerializeField] private AudioSource _soundDrive;
    [SerializeField] private AudioSource _soundEngine;

    public override void Happen()
    {
        _soundEngine.Stop();
        _soundDrive.Play();
        _blackScreen.DOFade(0, _duration);
    }
}
