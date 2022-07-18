using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsActivator : MonoBehaviour
{
    [SerializeField] private List<RandomEvent> _randomEvents;
    [SerializeField] private int _delayCalculate;

    private readonly int _maxPercent = 100;
    private readonly int _minPercent = 0;

    private void OnEnable()
    {
        StartCoroutine(Execute());
    }

    private void OnDisable()
    {
        StopCoroutine(Execute());
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
                    _randomEvents.RemoveAt(i);
                }

                yield return new WaitForSeconds(_delayCalculate);
            }

            yield return new WaitForSeconds(_delayCalculate);
        }
    }
}
