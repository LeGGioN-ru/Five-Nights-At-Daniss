using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PuareAttack : MonoBehaviour
{
    [SerializeField] private float _patience;
    [SerializeField] private Button _button;
    [SerializeField] private float _patienceUp;
    [SerializeField] private float _patienceDown;
    [SerializeField] private float _patienceDownDelay;
    [SerializeField] private GameObject _loadScreen;

    public event UnityAction<bool> PatienceEnded;
    public event UnityAction<float> PatienceChange;

    private void OnEnable()
    {
        StartCoroutine(LosingPatience());
        _button.onClick.AddListener(OnClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClick);
    }

    private void OnClick()
    {
        _patience += _patienceUp;
        _patience = Mathf.Clamp01(_patience);
        PatienceChange?.Invoke(_patience);
    }

    private IEnumerator LosingPatience()
    {
        while (_patience > 0)
        {
            _patience -= _patienceDown;
            PatienceChange?.Invoke(_patience);
            yield return new WaitForSeconds(_patienceDownDelay);
        }

        PatienceEnded?.Invoke(true);
    }
}
