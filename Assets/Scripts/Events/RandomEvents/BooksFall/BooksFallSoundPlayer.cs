using UnityEngine;

public class BooksFallSoundPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource _sound;
    
    public void Play()
    {
        _sound.Play();
    }
}
