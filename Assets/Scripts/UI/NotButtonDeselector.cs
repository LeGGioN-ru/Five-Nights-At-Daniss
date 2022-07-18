using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class NotButtonDeselector : MonoBehaviour
{
    [SerializeField] private List<ButtonSelector> _selecters;
    [SerializeField] private Button _firstSelected;

    private int _lastSelectedIndex;

    private void Start()
    {
        _firstSelected.Select();
        FindSelectedIndex();
    }

    private void FixedUpdate()
    {
        FindSelectedIndex();
    }

    private void FindSelectedIndex()
    {
        var lastSelectedIndex = _selecters.IndexOf(_selecters.FirstOrDefault(x => x.IsSelected));

        if (lastSelectedIndex == -1)
        {
            _selecters[_lastSelectedIndex].GetComponent<Button>().Select();
            return;
        }

        _lastSelectedIndex = lastSelectedIndex;
    }
}
