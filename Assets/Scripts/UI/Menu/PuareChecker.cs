using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuareChecker : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private int _levelNumber;

    private void Start()
    {
        var save = SaveChecker.TryGetSaveFile();

        if (save.LevelConfigurations[_levelNumber].IsPuareCollect)
        {
            _icon.enabled = true;
            return;
        }

        _icon.enabled = false;
    }
}
