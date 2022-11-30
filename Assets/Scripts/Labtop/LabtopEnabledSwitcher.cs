using UnityEngine;

public class LabtopEnabledSwitcher : MonoBehaviour
{
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private LabtopSwitcher _labtopSwitcher;
    [SerializeField] private InGameMainMenuInputer _inGameMainMenuInputer;

    private void OnEnable()
    {
        _startScreen.Started += Disable;
        _startScreen.Ended += Enable;
        _inGameMainMenuInputer.Opened += Disable;
        _inGameMainMenuInputer.Closed += Enable;
    }

    private void OnDisable()
    {
        _startScreen.Started -= Disable;
        _startScreen.Ended -= Enable;
    }

    private void Enable()
    {
        _labtopSwitcher.enabled = true;
    }

    private void Disable()
    {
        _labtopSwitcher.enabled = false;
    }
}
