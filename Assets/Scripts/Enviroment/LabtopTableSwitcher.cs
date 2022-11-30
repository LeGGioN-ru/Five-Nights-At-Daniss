using System.Collections;
using UnityEngine;

public class LabtopTableSwitcher : MonoBehaviour
{
    [SerializeField] private LabtopSwitcher _labtop;
    [SerializeField] private Table _table;
    [SerializeField]  private float _tableOpenDelay;

    private void OnEnable()
    {
        _labtop.Opened += OnLabtopOpen;
        _labtop.Closed += OnLabtopClose;
        _table.Hided += OnTableHide;
        _table.Incarnated += OnTableIncarnate;
    }

    private void OnDisable()
    {
        _labtop.Opened -= OnLabtopOpen;
        _labtop.Closed -= OnLabtopClose;
        _table.Hided -= OnTableHide;
        _table.Incarnated -= OnTableIncarnate;
    }

    private void OnTableHide()
    {
        _labtop.enabled = false;
    }
    private void OnTableIncarnate()
    {
        _labtop.enabled = true;
    }

    private void OnLabtopOpen()
    {
        _table.enabled = false;
    }

    private void OnLabtopClose()
    {
        StartCoroutine(UnlockTable());
    }

    private IEnumerator UnlockTable()
    {
        float passedTime = 0;

        while (passedTime < _tableOpenDelay)
        {
            passedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        _table.enabled = true;
    }
}
