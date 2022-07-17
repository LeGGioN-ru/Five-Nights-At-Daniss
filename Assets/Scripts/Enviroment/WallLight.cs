using UnityEngine;

[RequireComponent(typeof(Light))]
public class WallLight : MonoBehaviour
{
    [SerializeField] private WallButton _button;

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
            _light.enabled=false;
            return;
        }

        _light.enabled = true;
    }
}
