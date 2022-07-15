using UnityEngine;

public class PlayerLookerSwitcher : MonoBehaviour
{
    [SerializeField] private PlayerLooker _playerLooker;
    [SerializeField] private LabtopSwitcher _labtopSwitcher;

    private void OnEnable()
    {
        _labtopSwitcher.Opened += Disable;
        _labtopSwitcher.Closed += Enable;
    }

    private void OnDisable()
    {
        _labtopSwitcher.Opened -= Disable;
        _labtopSwitcher.Closed -= Enable;
    }

    private void Disable()
    {
        _playerLooker.enabled = false;
    }

    private void Enable()
    {
        _playerLooker.enabled = true;
    }
}
