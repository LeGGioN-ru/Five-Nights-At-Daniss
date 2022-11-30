using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintDropSound : MonoBehaviour
{
    [SerializeField] private AudioSource _sound;

    public void Play()
    {
        _sound.Play();
    }
}
