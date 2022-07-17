using UnityEngine;

public class PlayerInterface : MonoBehaviour
{
    [SerializeField] private LabtopSwitcher _labtopSwitcher;
    [SerializeField] private GameObject _aim;

    private void OnEnable()
    {
        _labtopSwitcher.Opened += HideAim;
        _labtopSwitcher.Closed += ShowAim;
    }

    private void OnDisable()
    {
        _labtopSwitcher.Opened -= HideAim;
        _labtopSwitcher.Closed -= ShowAim;
    }

    private void HideAim()
    {
        _aim.SetActive(false);
    }

    private void ShowAim()
    {
        _aim.SetActive(true);
    }
}
