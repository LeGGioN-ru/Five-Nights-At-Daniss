using UnityEngine;
using UnityEngine.UI;

public class Dopelganger : MonoBehaviour
{
    [SerializeField] private GameObject _dopelgangerIconCore;
    [SerializeField] private RoomRenderer[] _renderers;
    [SerializeField] private Image _dopelgangerImage;
    [SerializeField] private Sprite _dopelganger;
    [SerializeField] private Sprite _tripleganger;

    private void OnEnable()
    {
        foreach (var renderer in _renderers)
        {
            renderer.DanisesCome += OnDanisesCome;
            renderer.DanisesNotCome += OnDanisesNotCome;
        }
    }

    private void OnDisable()
    {
        foreach (var renderer in _renderers)
        {
            renderer.DanisesCome -= OnDanisesCome;
            renderer.DanisesNotCome -= OnDanisesNotCome;
        }
    }

    private void OnDanisesCome(int danisAmount)
    {
        if (danisAmount == 2)
        {
            _dopelgangerImage.sprite = _dopelganger;
        }
        else if (danisAmount == 3)
        {
            _dopelgangerImage.sprite = _tripleganger;
        }

        _dopelgangerIconCore.SetActive(true);
    }

    private void OnDanisesNotCome()
    {
        if (_dopelgangerIconCore.activeSelf == true)
        {
            _dopelgangerIconCore.SetActive(false);
        }
    }
}
