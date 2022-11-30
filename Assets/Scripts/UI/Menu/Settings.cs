using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField] private Button _backButton;
    [SerializeField] private GameObject _mainButtonsPanel;
    [SerializeField] private GameObject _settingsPanel;
    [SerializeField] private Slider _sliderVolume;
    [SerializeField] private AudioMixer _mixer;
    [SerializeField] private TMP_Dropdown _dropDownQuality;

    private void OnEnable()
    {
        _dropDownQuality.value = _dropDownQuality.options.Count - 1;
        SetSliderStartValue();

        _backButton.onClick.AddListener(OnBackButtonClick);
        _sliderVolume.onValueChanged.AddListener(OnSliderVolumeValueChange);
        _dropDownQuality.onValueChanged.AddListener(OnDropDownQualityChange);
    }

    private void OnDisable()
    {
        _backButton.onClick.RemoveListener(OnBackButtonClick);
        _sliderVolume.onValueChanged.RemoveListener(OnSliderVolumeValueChange);
        _dropDownQuality.onValueChanged.RemoveListener(OnDropDownQualityChange);
    }

    private void OnBackButtonClick()
    {
        _settingsPanel.SetActive(false);
        _mainButtonsPanel.SetActive(true);
    }

    private void SetSliderStartValue()
    {
        var save = SaveChecker.TryGetSaveFile();
        _sliderVolume.value = save.Volume;
    }

    private void OnSliderVolumeValueChange(float volume)
    {
        _mixer.SetFloat("Volume", volume);

        var save = SaveChecker.TryGetSaveFile();
        save.ChageVolume(volume);
    }

    private void OnDropDownQualityChange(int index)
    {
        switch (index)
        {
            case 1:
                index = 2;
                break;
            case 2:
                index = 5;
                break;
        }

        QualitySettings.SetQualityLevel(index);
    }
}
