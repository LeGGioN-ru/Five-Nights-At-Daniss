using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsActivator : MonoBehaviour
{
    [SerializeField] private List<RandomEvent> _randomEvents;
    [SerializeField] private int _delayCalculate;
    [SerializeField] private GameEnder _gameEnder;

    private readonly float _maxPercent = 1000f;
    private readonly float _minPercent = 0f;

    private void OnEnable()
    {
        StartCoroutine(Execute());
        _gameEnder.Ended += OnGameEnd;
    }

    private void OnDisable()
    {
        StopCoroutine(Execute());
        _gameEnder.Ended -= OnGameEnd;
    }

    private IEnumerator Execute()
    {
        while (true)
        {
            for (int i = 0; i < _randomEvents.Count; i++)
            {
                if (_randomEvents[i].Chance >= Random.Range(_minPercent, _maxPercent))
                {
                    _randomEvents[i].Happen();

                    if (_randomEvents[i].IsCanReply == false)
                    {
                        _randomEvents.RemoveAt(i);
                    }

                    yield return new WaitForSeconds(_delayCalculate);
                }
            }

            yield return new WaitForSeconds(_delayCalculate);
        }
    }

    private void OnGameEnd()
    {
        enabled = false;
    }
}
