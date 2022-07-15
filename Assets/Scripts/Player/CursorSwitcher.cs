using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorSwitcher : MonoBehaviour
{
    [SerializeField] private LabtopSwitcher _labtopSwitcher;

    private void OnEnable()
    {
        LockCursor();
        _labtopSwitcher.Opened += UnLockCursor;
        _labtopSwitcher.Closed += LockCursor;
    }

    private void OnDisable()
    {
        _labtopSwitcher.Opened -= UnLockCursor;
        _labtopSwitcher.Closed -= LockCursor;
    }

    private void LockCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void UnLockCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }
}
