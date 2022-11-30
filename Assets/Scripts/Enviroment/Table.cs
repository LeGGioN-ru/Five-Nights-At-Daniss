using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class Table : MonoBehaviour
{
    [SerializeField] private Transform _hidePoint;
    [SerializeField] private float _tickDelay;
    [SerializeField] private Transform _player;
    [SerializeField] private float _timeHideIncarnate;
    [SerializeField] private float _delay;

    public event UnityAction Ticked;
    public event UnityAction Hided;
    public event UnityAction Incarnated;

    private Tween _animation;
    private Vector3 _startPoint;
    private Coroutine _tick;
    private bool _isPlayerHide;
    private float _passedTime;

    private void Start()
    {
        _startPoint = _player.transform.position;
    }

    private void Update()
    {
        _passedTime += Time.deltaTime;

        if (_passedTime < _delay)
            return;

        if (Input.GetKeyDown(KeyCode.W) && _isPlayerHide)
            Incarnate();
        else if (Input.GetKeyDown(KeyCode.S) && _isPlayerHide == false)
            Hide();
    }

    private void Incarnate()
    {
        _isPlayerHide = !_isPlayerHide;

        Incarnated?.Invoke();
        _player.DOMove(_startPoint, _timeHideIncarnate);

        if (_tick != null)
        {
            StopCoroutine(_tick);
        }

        _passedTime = 0;
    }

    private void Hide()
    {
        _isPlayerHide = !_isPlayerHide;

        _player.DOMove(_hidePoint.position, _timeHideIncarnate);
        _animation.SetAutoKill(false);

        Hided?.Invoke();

        _tick = StartCoroutine(Tick());

        _passedTime = 0;
    }

    private IEnumerator Tick()
    {
        while (true)
        {
            Ticked?.Invoke();
            yield return new WaitForSeconds(_tickDelay);
        }
    }
}
