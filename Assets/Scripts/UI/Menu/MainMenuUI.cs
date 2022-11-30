using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] protected Button PlayButton;
    [SerializeField] protected Button SettingsButton;
    [SerializeField] protected Button ExitButton;
    [SerializeField] protected GameObject SettingsPanel;
    [SerializeField] private GameObject _levelsPanel;
    [SerializeField] protected GameObject MainButtonsPanel;
    [SerializeField] private Button _danispediaButton;
    [SerializeField] private Danispedia _danispedia;

    public UnityAction DanispediaOpened;

    protected virtual void OnEnable()
    {
        PlayButton.onClick.AddListener(Play);
        SettingsButton.onClick.AddListener(OnButtonSettingsClick);
        ExitButton.onClick.AddListener(OnExitButtonClick);

        if (_danispediaButton != null)
        {
            _danispediaButton.onClick.AddListener(OnDanispediaClick);
        }
    }

    protected virtual void OnDisable()
    {
        PlayButton.onClick.RemoveListener(Play);
        SettingsButton.onClick.RemoveListener(OnButtonSettingsClick);
        ExitButton.onClick.RemoveListener(OnExitButtonClick);

        if (_danispediaButton != null)
        {
            _danispediaButton.onClick.RemoveListener(OnDanispediaClick);
        }
    }

    protected virtual void OnExitButtonClick()
    {
        Application.Quit();
    }

    private void OnButtonSettingsClick()
    {
        MainButtonsPanel.SetActive(false);
        SettingsPanel.SetActive(true);
    }

    private void OnDanispediaClick()
    {
        _danispedia.gameObject.SetActive(true);
        DanispediaOpened?.Invoke();
    }

    protected virtual void Play()
    {
        MainButtonsPanel.SetActive(false);
        _levelsPanel.SetActive(true);
    }
}
