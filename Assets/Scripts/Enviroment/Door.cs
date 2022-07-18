using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public class Door : MonoBehaviour
{
    [SerializeField] private bool _isLeftDoor;
    [SerializeField] private Transform _endPoint;
    [SerializeField] private WallButton _button;
    [SerializeField] private float _animationSpeed;

    public event UnityAction<bool> Closed;
    public event UnityAction<bool> Opened;

    private bool _isOpen = true;
    [SerializeField] private Transform _startPoint;

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
        _isOpen = !_isOpen;

        if (_isOpen)
        {
            Open();
            Opened?.Invoke(_isLeftDoor);
            return;
        }

        Closed?.Invoke(_isLeftDoor);
        Close();
    }

    private void Open()
    {
        transform.DOMove(_startPoint.position, _animationSpeed);
    }

    private void Close()
    {
        transform.DOMove(_endPoint.position, _animationSpeed);
    }
}
