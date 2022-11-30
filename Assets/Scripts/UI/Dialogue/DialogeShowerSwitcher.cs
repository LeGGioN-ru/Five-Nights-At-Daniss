using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogeShowerSwitcher : MonoBehaviour
{
    [SerializeField] private DialogePanel _dialogePanel;
    [SerializeField] private NamePanel _namePanel;
    [SerializeField] private InGameMainMenuInputer _inputer;

    private void OnEnable()
    {
        _inputer.Opened += Hide;
        _inputer.Closed += Show;
    }

    private void OnDisable()
    {
        _inputer.Opened -= Hide;
        _inputer.Closed -= Show;
    }

    private void Show()
    {
        _dialogePanel.gameObject.SetActive(true);
        _namePanel.gameObject.SetActive(true);
    }

    private void Hide()
    {
        _dialogePanel.gameObject.SetActive(false);
        _namePanel.gameObject.SetActive(false);
    }
}
