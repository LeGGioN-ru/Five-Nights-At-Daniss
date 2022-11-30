using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class StartScreen : MonoBehaviour
{
    [SerializeField] private Button _endScreenButton;
    [SerializeField] private GameObject _epanetionsScreen;
    [SerializeField] private GameObject _loadScreen;

    public event UnityAction Started;
    public event UnityAction Ended;

    private void OnEnable()
    {
        _endScreenButton.onClick.AddListener(OnEndButtonClick);
    }

    private void OnDisable()
    {
        _endScreenButton.onClick.RemoveListener(OnEndButtonClick);
    }

    private void Start()
    {
        Time.timeScale = 0;
        Started?.Invoke();
    }

    private void OnEndButtonClick()
    {
        Ended?.Invoke();
        Time.timeScale = 1;
        _epanetionsScreen.SetActive(false);
    }
}
