using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CurrentTime : MonoBehaviour
{
    [SerializeField] private TMP_Text _time;
    [SerializeField] private GameEnder _gameEnder;

    private void OnEnable()
    {
        _gameEnder.TimeChanged += OnTimeChange;
    }

    private void OnDisable()
    {
        _gameEnder.TimeChanged -= OnTimeChange;
    }

    private void OnTimeChange(int hour)
    {
        _time.text = $"Ночь {_gameEnder.LevelNumber + 1}\n{hour}:00";
    }
}
