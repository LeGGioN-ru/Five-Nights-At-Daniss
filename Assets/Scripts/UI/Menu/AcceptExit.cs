using IJunior.TypedScenes;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class AcceptExit : MonoBehaviour
{
    [SerializeField] private Button _yesButton;
    [SerializeField] private Button _noButton;
    [SerializeField] private GameObject _applyPanel;
    [SerializeField] private GameObject _mainButtonsPanel;

    public event UnityAction OnAcceptExit;

    private void OnEnable()
    {
        _yesButton.onClick.AddListener(OnYesButtonPress);
        _noButton.onClick.AddListener(OnNoButtonPress);
    }

    private void OnDisable()
    {
        _yesButton.onClick.RemoveListener(OnYesButtonPress);
        _noButton.onClick.RemoveListener(OnNoButtonPress);
    }

    private void OnYesButtonPress()
    {
        OnAcceptExit?.Invoke();
        MainMenu.Load(new LevelConfiguration(false, false, 0));
    }

    private void OnNoButtonPress()
    {
        _applyPanel.SetActive(false);
        _mainButtonsPanel.SetActive(true);
    }
}
