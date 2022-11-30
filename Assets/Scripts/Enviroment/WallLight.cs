using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Light))]
public class WallLight : MonoBehaviour
{
    [SerializeField] private WallButton _button;
    [SerializeField] private bool _isLeftLight;
    [SerializeField] private float _tickDelay;
    [SerializeField] private Battery _battery;

    public event UnityAction<bool> Enabled;
    public event UnityAction<bool> Disabled;
    public event UnityAction<bool> Ticked;

    private Coroutine _tick;
    private Light _light;
    private bool _isOn = true;

    private void Start()
    {
        _light = GetComponent<Light>();
    }

    private void OnEnable()
    {
        _button.Press += Switch;
        _battery.StockEnded += Disable;
    }

    private void OnDisable()
    {
        _button.Press -= Switch;
        _battery.StockEnded -= Disable;
    }

    private void Switch()
    {
        _isOn = !_isOn;

        if (_isOn)
        {
            Disable();
            return;
        }

        Enable();
    }

    private void Enable()
    {
        _tick = StartCoroutine(Tick());
        Enabled?.Invoke(_isLeftLight);
        _light.enabled = true;
    }


    private void Disable()
    {
        if (_tick != null)
        {
            StopCoroutine(_tick);
        }

        Disabled?.Invoke(_isLeftLight);
        _light.enabled = false;
    }

    private IEnumerator Tick()
    {
        while (true)
        {
            Ticked?.Invoke(_isLeftLight);
            yield return new WaitForSeconds(_tickDelay);
        }
    }
}
