using UnityEngine;

public class WindowBroke : RandomEvent
{
    [SerializeField] private Animator _animator;
    [SerializeField] private AudioSource[] _sounds;
    [SerializeField] private AudioSource _rainSound;
    [SerializeField] private float _addedRainSound;

    public override void Happen()
    {
        foreach (var sound in _sounds)
        {
            sound.Play();
        }

        _rainSound.volume += _addedRainSound;

        _animator.Play(WindowAnimator.Animation.Window);
    }
}
