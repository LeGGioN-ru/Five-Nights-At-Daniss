using UnityEngine;
using DG.Tweening;

public class PlayerLabtopLooker : MonoBehaviour
{
    [SerializeField] private Transform _labtopLookPoint;
    [SerializeField] private Transform _endPoint;
    [SerializeField] private float _speedAnimations;
    [SerializeField] private LabtopSwitcher _labtopSwitcher;
    [SerializeField] private PlayerLooker _playerLooker;

    private Camera _player;
    private Vector3 _startPoint;

    private void Start()
    {
        _player = Camera.main;
        _startPoint = _player.transform.position;
    }

    private void OnEnable()
    {
        _labtopSwitcher.Opened += LookOn;
        _labtopSwitcher.Closed += LookOut;
    }

    private void OnDisable()
    {
        _labtopSwitcher.Opened -= LookOn;
        _labtopSwitcher.Closed -= LookOut;
    }

    private void LookOn()
    {
        _player.transform.DOMove(_endPoint.position, _speedAnimations);
        _player.transform.DORotate(new Vector3(_labtopLookPoint.position.x, _labtopLookPoint.position.y, 0), _speedAnimations);
    }

    private void LookOut()
    {
        _player.transform.DOMove(_startPoint, _speedAnimations);
        _playerLooker.ResetRotation();
    }
}