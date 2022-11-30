using UnityEngine;

public class PlayerLookerSwitcher : MonoBehaviour
{
    [SerializeField] private PlayerLooker _playerLooker;
    [SerializeField] private LabtopSwitcher _labtopSwitcher;
    [SerializeField] protected InGameMainMenuInputer Inputer;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private JumpScare _jumpScare;

    protected virtual void OnEnable()
    {
        _jumpScare.Started += Disable;
        _startScreen.Started += Disable;
        _startScreen.Ended += Enable;
        _labtopSwitcher.Opened += Disable;
        _labtopSwitcher.Closed += Enable;
        Inputer.Opened += Disable;
        Inputer.Closed += Enable;
    }

    protected virtual void OnDisable()
    {
        _jumpScare.Started -= Disable;
        _labtopSwitcher.Opened -= Disable;
        _labtopSwitcher.Closed -= Enable;
        Inputer.Opened -= Disable;
        Inputer.Closed -= Enable;
        _startScreen.Started -= Disable;
        _startScreen.Ended -= Enable;
    }

    protected void Disable()
    {
        _playerLooker.enabled = false;
    }

    protected void Enable()
    {
        _playerLooker.enabled = true;
    }
}
