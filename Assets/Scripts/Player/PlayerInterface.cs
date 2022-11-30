using UnityEngine;

public class PlayerInterface : MonoBehaviour
{
    [SerializeField] private LabtopSwitcher _labtopSwitcher;
    [SerializeField] private GameObject _aim;
    [SerializeField] private GameEnder _gameEnder;

    private void OnEnable()
    {
        _labtopSwitcher.Opened += HideAim;
        _labtopSwitcher.Closed += ShowAim;
        _gameEnder.Ended += OnGameEnd;
    }

    private void OnDisable()
    {
        _labtopSwitcher.Opened -= HideAim;
        _labtopSwitcher.Closed -= ShowAim;
        _gameEnder.Ended -= OnGameEnd;
    }

    private void HideAim()
    {
        _aim.SetActive(false);
    }

    private void ShowAim()
    {
        _aim.SetActive(true);
    }

    private void OnGameEnd()
    {
        gameObject.SetActive(false);
    }
}
