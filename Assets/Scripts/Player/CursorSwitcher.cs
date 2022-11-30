using UnityEngine;

public class CursorSwitcher : MonoBehaviour
{
    [SerializeField] private LabtopSwitcher _labtopSwitcher;
    [SerializeField] private InGameMainMenuInputer _inputer;
    [SerializeField] private GameEnder _gameEnder;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private JumpScare _jumpScare;
    [SerializeField] private bool _isGameEnd = false;

    private void OnEnable()
    {
        LockCursor();

        if (_inputer != null)
        {
            _inputer.Opened += UnLockCursor;
            _inputer.Closed += LockCursor;
        }

        if (_isGameEnd)
            return;

        _startScreen.Started += UnLockCursor;
        _startScreen.Ended += LockCursor;
        _labtopSwitcher.Opened += UnLockCursor;
        _labtopSwitcher.Closed += LockCursor;
        _gameEnder.Ended += UnLockCursor;
        _jumpScare.Executed += UnLockCursor;
    }

    private void OnDisable()
    {
        if (_isGameEnd)
            return;

        if (_inputer != null)
        {
            _inputer.Opened -= UnLockCursor;
            _inputer.Closed -= LockCursor;
        }

        _startScreen.Started -= UnLockCursor;
        _startScreen.Ended -= LockCursor;
        _labtopSwitcher.Opened -= UnLockCursor;
        _labtopSwitcher.Closed -= LockCursor;
        _gameEnder.Ended -= UnLockCursor;
        _jumpScare.Executed -= UnLockCursor;
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
