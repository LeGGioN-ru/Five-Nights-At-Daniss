using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using DG.Tweening;

public class EndVideo : MonoBehaviour
{
    [SerializeField] private VideoPlayer _player;
    [SerializeField] private RawImage _videoImage;
    [SerializeField] private float _duration;
    [SerializeField] private PlayerMoverActivator _moverActivator;

    private float _passedTime;
    private bool _isVideoEnd;

    private void Start()
    {
        _player.Play();
    }

    private void Update()
    {
        _passedTime += Time.deltaTime;

        if (_passedTime >= _player.clip.length && _isVideoEnd == false)
        {
            _isVideoEnd = true;
            _moverActivator.enabled = true;
            _videoImage.DOFade(0, _duration).OnComplete(() => Destroy(this));
        }
    }
}
