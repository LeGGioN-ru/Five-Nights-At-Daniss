using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class Button : MonoBehaviour
{
    [SerializeField] private Transform _endPoint;
    [SerializeField] private float _animationSpeed;

    public event UnityAction Pressed;

    private Sequence sequence;

    private void Start()
    {
        sequence = DOTween.Sequence().SetAutoKill(false).Pause();
        sequence.Append(transform.DOMove(_endPoint.position, _animationSpeed));
        sequence.Append(transform.DOMove(transform.position, _animationSpeed));
    }

    public void Clicked()
    {
        Debug.Log("got");

        if (sequence.IsPlaying() == false)
        {
            sequence.Restart();
            Pressed?.Invoke();
        }
    }
}
