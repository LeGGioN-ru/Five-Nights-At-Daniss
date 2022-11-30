using UnityEngine;
using UnityEngine.Audio;

public class StartVolumeSetter : MonoBehaviour
{
    [SerializeField] private AudioMixer _mixer;

    private void Start()
    {
        var save = SaveChecker.TryGetSaveFile();

        _mixer.SetFloat("Volume", save.Volume);
    }
}
