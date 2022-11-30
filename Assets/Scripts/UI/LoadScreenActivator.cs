using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadScreenActivator : MonoBehaviour
{
    [SerializeField] private GameObject _loadScreen;
    [SerializeField] private AcceptExit _acceptExit;
    [SerializeField] private JumpScare _jumpScare;
    [SerializeField] private GameEnder _gameEnder;

    private void OnEnable()
    {
        _acceptExit.OnAcceptExit += Enable;
        _jumpScare.Executed += Enable;
    }

    private void OnDisable()
    {
        _acceptExit.OnAcceptExit -= Enable;
        _jumpScare.Executed -= Enable;
    }

    private void Enable()
    {
        _loadScreen.SetActive(true);
    }
}
