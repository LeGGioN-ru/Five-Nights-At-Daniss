using DG.Tweening;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class DanisDetector : MonoBehaviour
{
    [SerializeField] private float _escapeTime;
    [SerializeField] private float _dieTime;
    [SerializeField] private float _distanceDetect;

    private AudioSource _sound;
    private Transform _endPoint;
    private bool _isHidden = true;

    private void Start()
    {
        _sound = GetComponent<AudioSource>();
    }

    public void Init(Transform endPoint)
    {
        _endPoint = endPoint;
    }

    private void Update()
    {
        if (_isHidden)
        {
            Vector3 point = Camera.main.ViewportToWorldPoint(transform.position);

            if (point.x >= -_distanceDetect && point.x < _distanceDetect && point.z < 0)
            {
                _isHidden = false;
                _sound.Play();
                StartCoroutine(Die());
            }
        }
    }

    private IEnumerator Die()
    {
        float passedTime = 0;

        transform.DOMove(_endPoint.position, _escapeTime);

        while (passedTime < _dieTime)
        {
            passedTime += Time.deltaTime;
            yield return null;
        }

        Destroy(gameObject);
    }
}
