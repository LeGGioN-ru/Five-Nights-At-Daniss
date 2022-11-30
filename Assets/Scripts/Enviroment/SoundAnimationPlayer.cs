using UnityEngine;

public class SoundAnimationPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource _sound;

    public void Play()
    {
        _sound.Play();
    }
}
