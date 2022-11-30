using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Battery : MonoBehaviour
{
    [SerializeField] private float _maxStock;
    [SerializeField] private Door[] _doors;
    [SerializeField] private WallLight[] _wallLights;
    [SerializeField] private float _doorStockDown;
    [SerializeField] private float _lightStockDown;
    [SerializeField] private float _stockUpdateDelay;
    [SerializeField] private RedLamp _redLamp;

    public event UnityAction StockEnded;
    public event UnityAction<float> Downed;

    public float CurrentStock => _currentStock;

    private Coroutine _leftLightCoroutine;
    private Coroutine _rightLightCoroutine;
    private Coroutine _leftDoorCoroutine;
    private Coroutine _rightDoorCoroutine;
    private float _currentStock;

    private void Start()
    {
        _currentStock = _maxStock;
    }

    private void OnEnable()
    {
        foreach (var door in _doors)
        {
            door.Closed += OnClosed;
            door.Opened += OnOpened;
        }

        foreach (var light in _wallLights)
        {
            light.Enabled += OnEnabled;
            light.Disabled += OnDisabled;
        }

        _redLamp.Ended += OnRedLampEnded;
    }

    private void OnDisable()
    {
        foreach (var door in _doors)
        {
            door.Closed -= OnClosed;
            door.Opened -= OnOpened;
        }

        foreach (var light in _wallLights)
        {
            light.Enabled -= OnEnabled;
            light.Disabled -= OnDisabled;
        }

        _redLamp.Ended -= OnRedLampEnded;
    }

    private void OnOpened(bool isLeftSide)
    {
        if (isLeftSide)
        {
            if (_leftDoorCoroutine != null)
            {
                StopCoroutine(_leftDoorCoroutine);
            }

            return;
        }

        if (_rightDoorCoroutine != null)
        {
            StopCoroutine(_rightDoorCoroutine);
        }
    }

    private void OnClosed(bool isLeftSide)
    {
        if (isLeftSide)
        {
            _leftDoorCoroutine = StartCoroutine(RemoveStock(_doorStockDown));
            return;
        }

        _rightDoorCoroutine = StartCoroutine(RemoveStock(_doorStockDown));
    }

    private void OnEnabled(bool isLeftSide)
    {
        if (isLeftSide)
        {
            _leftLightCoroutine = StartCoroutine(RemoveStock(_lightStockDown));
            return;
        }

        _rightLightCoroutine = StartCoroutine(RemoveStock(_lightStockDown));
    }

    private void OnDisabled(bool isLeftSide)
    {
        if (isLeftSide)
        {
            if (_leftLightCoroutine != null)
            {
                StopCoroutine(_leftLightCoroutine);
            }

            return;
        }

        if (_rightLightCoroutine != null)
        {
            StopCoroutine(_rightLightCoroutine);
        }
    }

    private IEnumerator RemoveStock(float stockDown)
    {
        while (_currentStock >= 0)
        {
            _currentStock -= stockDown;
            Downed?.Invoke(_currentStock);
            yield return new WaitForSeconds(_stockUpdateDelay);
        }

        StockEnded?.Invoke();
    }

    private void OnRedLampEnded()
    {
        Downed?.Invoke(_currentStock);
    }
}
