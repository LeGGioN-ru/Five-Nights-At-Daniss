using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemeRandomizer : MonoBehaviour
{
    [SerializeField] private List<Sprite> _memes;
    [SerializeField] private Image[] _places;

    private void Start()
    {
        foreach (var place in _places)
        {
            int randomIndex = Random.Range(0, _memes.Count);
            place.sprite = _memes[randomIndex];
            _memes.RemoveAt(randomIndex);
        }
    }
}
