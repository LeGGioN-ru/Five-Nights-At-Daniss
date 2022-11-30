 using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;
using System.Collections;

public class Door : MonoBehaviour
{
    [SerializeField] private bool _isLeftDoor;
    [SerializeField] private Transform _endPoint;
    [SerializeField] private WallButton _button;
    [SerializeField] private float _animationSpeed;
    [SerializeField] private Transform _startPoint;
    [SerializeField] private float _tickDelay;
    [SerializeField] private Battery _battery;
    [SerializeField] private AudioSource _sounOpen;
    [SerializeField] private AudioSource _soundClose;

    public event UnityAction<bool> Closed;
    public event UnityAction<bool> Opened;
    public event UnityAction<bool> Ticked;

    private Coroutine _tick;
    private bool _isOpen = true;


    private void OnEnable()
    {
        _button.Press += Switch;
        _battery.StockEnded += Open;
    }

    private void OnDisable()
    {
        _button.Press -= Switch;
        _battery.StockEnded -= Open;
    }

    private void Switch()
    {
        _isOpen = !_isOpen;

        if (_isOpen)
        {
            Open();
            return;
        }

        Close();
    }

    private void Open()
    {
        if (_tick != null)
        {
            StopCoroutine(_tick);
        }

        _sounOpen.Play();
        Opened?.Invoke(_isLeftDoor);
        transform.DOMove(_startPoint.position, _animationSpeed);
    }

    private void Close()
    {
        _tick = StartCoroutine(Tick());
        _soundClose.Play();
        Closed?.Invoke(_isLeftDoor);
        transform.DOMove(_endPoint.position, _animationSpeed);
    }

    private IEnumerator Tick()
    {
        while (true)
        {
            Ticked?.Invoke(_isLeftDoor);
            yield return new WaitForSeconds(_tickDelay);
        }
    }
}
