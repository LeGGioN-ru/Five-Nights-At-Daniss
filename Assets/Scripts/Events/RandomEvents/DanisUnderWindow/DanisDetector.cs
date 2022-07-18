using DG.Tweening;
using System.Collections;
using UnityEngine;

public class DanisDetector : MonoBehaviour
{
    [SerializeField] private float _escapeTime;
    [SerializeField] private float _distanceDetect;

    private Transform _endPoint;
    private bool _isHidden = true;

    public void Init(Transform endPoint)
    {
        _endPoint = endPoint;
    }

    private void Update()
    {
        if (_isHidden)
        {
            Vector3 point = Camera.main.ViewportToWorldPoint(transform.position);

            if (point.x >= -_distanceDetect && point.x < _distanceDetect)
            {
                _isHidden = false;
                StartCoroutine(Die());
            }
        }
    }

    private IEnumerator Die()
    {
        float passedTime = 0;

        transform.DOMove(_endPoint.position, _escapeTime);

        while (passedTime < _escapeTime)
        {
            passedTime += Time.deltaTime;
            yield return null;
        }

        Destroy(gameObject);
    }
}
