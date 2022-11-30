using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuLoadScreen : MonoBehaviour
{
    [SerializeField] private GameObject _loadScreen;
    [SerializeField] private LevelSelector _levelSelector;

    private void OnEnable()
    {
        _levelSelector.SceneLoaded += Enable;
    }

    private void OnDisable()
    {
        _levelSelector.SceneLoaded -= Enable;
    }

    private void Enable()
    {
        _loadScreen.SetActive(true);
    }
}
