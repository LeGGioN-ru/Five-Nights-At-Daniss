using UnityEngine;

public class InGameMainMenuSwitcher : MonoBehaviour
{
    [SerializeField] private InGameMainMenuInputer _inputer;
    [SerializeField] private LabtopEnabledSwitcher _labtopEnableSwithcer;
    [SerializeField] private StartScreen _startScreen;

    private void OnEnable()
    {
        if (_startScreen != null)
        {
            _startScreen.Started += Disable;
            _startScreen.Ended += Enable;
        }
    }

    private void OnDisable()
    {
        if (_startScreen != null)
        {
            _startScreen.Started -= Disable;
            _startScreen.Ended -= Enable;
        }
    }

    private void Enable()
    {
        _inputer.enabled = true;
    }

    private void Disable()
    {
        _inputer.enabled = false;
    }
}
