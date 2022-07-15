using UnityEngine;
using UnityEngine.Events;

public class LabtopSwitcher : MonoBehaviour
{
    [SerializeField] private Animator _labtopAnimator;

    public UnityAction Opened;
    public UnityAction Closed;

    private bool _isLabtopOpen;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _isLabtopOpen = !_isLabtopOpen;

            if (_isLabtopOpen)
            {
                Open();
                return;
            }

            Close();
        }
    }

    private void Open()
    {
        _labtopAnimator.Play(LabtopAnimator.Animation.Open);
        Opened?.Invoke();
    }

    private void Close()
    {
        _labtopAnimator.Play(LabtopAnimator.Animation.Close);
        Closed?.Invoke();
    }
}
