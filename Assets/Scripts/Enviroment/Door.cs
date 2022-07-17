using UnityEngine;
using DG.Tweening;

public class Door : MonoBehaviour
{
    [SerializeField] private bool _isLeftDoor;
    [SerializeField] private Transform _endPoint;
    [SerializeField] private WallButton _button;
    [SerializeField] private float _animationSpeed;

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
            return;
        }

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
