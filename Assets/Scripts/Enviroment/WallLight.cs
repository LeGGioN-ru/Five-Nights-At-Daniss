using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Light))]
public class WallLight : MonoBehaviour
{
    [SerializeField] private WallButton _button;
    [SerializeField] private bool _isLeftLight;

    public event UnityAction<bool> Enabled;
    public event UnityAction<bool> Disabled;

    private Light _light;
    private bool _isOn = true;

    private void Start()
    {
        _light = GetComponent<Light>();
    }

    private void OnEnable()
    {
        _button.Press += Switch;
    }

    private void OnDisable()
    {
        _button.Press -= Switch;
    }

    private void Switch()
    {
        _isOn = !_isOn;

        if (_isOn)
        {
            _light.enabled = false;
            Disabled?.Invoke(_isLeftLight);
            return;
        }

        Enabled?.Invoke(_isLeftLight);
        _light.enabled = true;
    }
}
