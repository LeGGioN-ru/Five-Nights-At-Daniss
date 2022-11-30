using UnityEngine;

public class PuarchikDetector : MonoBehaviour
{
    [SerializeField] private ObjectFinder _finder;
    [SerializeField] private AudioSource _sound;

    public bool IsCollect { get; private set; }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_finder.TryFindObject(out Puarchik puarchik))
            {
                IsCollect = true;
                _sound.Play();
                puarchik.Collect();
            }
        }
    }
}
