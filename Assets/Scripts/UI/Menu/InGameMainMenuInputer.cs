using UnityEngine;
using UnityEngine.Events;

public class InGameMainMenuInputer : MonoBehaviour
{
    private bool _isOpen;

    public event UnityAction Opened;
    public event UnityAction Closed;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _isOpen = !_isOpen;

            if (_isOpen)
            {
                Opened?.Invoke();
                return;
            }

            Closed?.Invoke();
        }
    }

    public void ClosePanel()
    {
        Closed?.Invoke();
    }
}
