using UnityEngine;

public class BackgroundMusicSwitcher : DialogueEvent
{
    [SerializeField] private AudioSource _music;
    [SerializeField] private bool _isStartMusic;

    public override void Happen()
    {
        if (_isStartMusic)
        {
            _music.Play();
            return;
        }

        _music.Stop();
    }
}
