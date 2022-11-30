using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameEndScreen : MonoBehaviour
{
    [SerializeField] private float _fadeTime;
    [SerializeField] private CanvasGroup _endScreenPanel;
    [SerializeField] private GameEnder _gameEnder;
    [SerializeField] private GameObject _endScreen;

    public event UnityAction Ended;

    private void OnEnable()
    {
        _gameEnder.Ended += OnGameEnd;
    }

    private void OnDisable()
    {
        _gameEnder.Ended -= OnGameEnd;
    }

    private void OnGameEnd()
    {
        _endScreen.SetActive(true);
        var tween = _endScreenPanel.DOFade(1, _fadeTime).SetAutoKill(false);
        tween.OnComplete(() => Ended?.Invoke());
    }
}
