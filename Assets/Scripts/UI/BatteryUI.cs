using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BatteryUI : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Image _fill;
    [SerializeField] private Gradient _gradient;
    [SerializeField] private Battery _battery;
    [SerializeField] private TMP_Text _text;

    private void OnEnable()
    {
        _fill.color = _gradient.Evaluate(1);

        _battery.Downed += SetValue;
    }

    private void OnDisable()
    {
        _battery.Downed -= SetValue;
    }

    private void SetValue(float value)
    {
        _text.text = $"{Convert.ToInt32(value)}%";
        _fill.color = _gradient.Evaluate(_slider.normalizedValue);
        _slider.value = value / 100;
    }
}
