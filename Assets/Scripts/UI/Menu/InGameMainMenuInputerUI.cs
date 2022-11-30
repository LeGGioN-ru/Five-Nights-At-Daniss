using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMainMenuInputerUI : MainMenuUI
{
    [SerializeField] private GameObject _acceptingPanel;
    [SerializeField] private GameObject _corePanel;
    [SerializeField] private InGameMainMenuInputer _inputer;

    protected override void OnEnable()
    {
        base.OnEnable();
        _inputer.Opened += OnOpen;
        _inputer.Closed += Play;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        _inputer.Opened -= OnOpen;
        _inputer.Closed -= Play;
        PlayButton.onClick.AddListener(_inputer.ClosePanel);
    }

    protected override void OnExitButtonClick()
    {
        _acceptingPanel.SetActive(true);
        MainButtonsPanel.SetActive(false);
        PlayButton.onClick.RemoveListener(_inputer.ClosePanel );
    }

    protected override void Play()
    {
        Time.timeScale = 1;

        _corePanel.SetActive(false);
    }

    private void OnOpen()
    {
        Time.timeScale = 0;

        _corePanel.SetActive(true);
        SettingsPanel.SetActive(false);
        _acceptingPanel.SetActive(false);
        MainButtonsPanel.SetActive(true);
    }
}
