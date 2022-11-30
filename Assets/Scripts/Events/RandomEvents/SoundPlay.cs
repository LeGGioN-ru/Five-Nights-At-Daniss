using UnityEngine;

public class SoundPlay : RandomEvent
{
    [SerializeField] private AudioSource _sound;

    public override void Happen()
    {
        _sound.Play();
    }
}
