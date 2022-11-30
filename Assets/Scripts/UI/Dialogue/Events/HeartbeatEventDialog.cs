using DG.Tweening;
using UnityEngine;

public class HeartbeatEventDialog : DialogueEvent
{
    [SerializeField] private AudioSource _heartbeat;
    [SerializeField] private float _newPitch;
    [SerializeField] private float _changeDuration;

    public override void Happen()
    {
        if (_heartbeat.isPlaying == false)
        {
            _heartbeat.Play();
        }

        _heartbeat.DOPitch(_newPitch,_changeDuration);
    }
}
