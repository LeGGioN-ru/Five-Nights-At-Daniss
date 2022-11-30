using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class NotButtonDeselector : MonoBehaviour
{
    [SerializeField] private List<ButtonSelector> _selecters;
    [SerializeField] private Button _firstSelected;
    [SerializeField] private float _deselectDelayCheck;

    private int _lastSelectedIndex;

    private void Start()
    {
        _firstSelected.Select();
    }

    private void OnEnable()
    {
        foreach (var selector in _selecters)
        {
            selector.DeSelected += OnDeselect;
            selector.Selected += OnSelect;
        }
    }

    private void OnDisable()
    {
        foreach (var selector in _selecters)
        {
            selector.Selected -= OnSelect;
            selector.DeSelected -= OnDeselect;
        }
    }

    private void OnSelect()
    {
        _lastSelectedIndex = _selecters.IndexOf(_selecters.FirstOrDefault(x => x.IsSelected));
    }

    private void OnDeselect()
    {
        StartCoroutine(CheckWithDelay());
    }

    private IEnumerator CheckWithDelay()
    {
        float passedTime = 0;
        bool isSelected = false;

        while (passedTime < _deselectDelayCheck)
        {
            passedTime += Time.deltaTime;
            yield return null;
        }

        foreach (var item in _selecters)
        {
            if (item.IsSelected == true)
            {
                isSelected = true;
            }
        }

        if (isSelected == false)
        {
            _selecters[_lastSelectedIndex].GetComponent<Button>().Select();
        }
    }
}
