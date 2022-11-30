using UnityEngine;
using UnityEngine.Events;

public class LabtopSwitcher : MonoBehaviour
{
    [SerializeField] private Animator _labtopAnimator;
    [SerializeField] private AudioSource _openLabtop;
    [SerializeField] private AudioSource _closeLabtop;

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
        _openLabtop.Play();
        Opened?.Invoke();
    }

    private void Close()
    {
        _labtopAnimator.Play(LabtopAnimator.Animation.Close);
        _closeLabtop.Play();
        Closed?.Invoke();
    }
}
