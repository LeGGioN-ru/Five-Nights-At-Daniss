using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

[RequireComponent(typeof(AudioSource))]
public class WallButton : MonoBehaviour
{
    [SerializeField] private Transform _endPoint;
    [SerializeField] private float _animationSpeed;
    [SerializeField] private Battery _battery;

    public event UnityAction Press;

    private bool _isActive = true;
    private AudioSource[] _sounds;
    private Sequence sequence;

    private void OnEnable()
    {
        _battery.StockEnded += Disactive;
    }

    private void OnDisable()
    {
        _battery.StockEnded -= Disactive;
    }

    private void Start()
    {
        _sounds = GetComponents<AudioSource>();
        sequence = DOTween.Sequence().SetAutoKill(false).Pause();
        sequence.Append(transform.DOMove(_endPoint.position, _animationSpeed));
        sequence.Append(transform.DOMove(transform.position, _animationSpeed));
    }

    public void Clicked()
    {
        if (sequence.IsPlaying() == false)
        {
            sequence.Restart();
            _sounds[Random.Range(0, _sounds.Length)].Play();

            if (_isActive)
            {
                Press?.Invoke();
            }
        }
    }

    private void Disactive()
    {
        _isActive = false;
    }
}
