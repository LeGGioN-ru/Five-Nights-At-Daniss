using System.Collections;
using UnityEngine;
using DG.Tweening;

public class EyeIncarnation : RandomEvent
{
    [SerializeField] private GameObject _eyes;
    [SerializeField] private Transform _incarnationPoint;
    [SerializeField] private AudioSource _sound;
    [SerializeField] private float _hideBeforeDelay;

    private GameObject _object;

    public override void Happen()
    {
        _sound.Play();
        _object = Instantiate(_eyes, _incarnationPoint);
        StartCoroutine(HideAfter());
    }

    private IEnumerator HideAfter()
    {
        float passedTime = 0;

        while (passedTime < _hideBeforeDelay)
        {
            passedTime += Time.deltaTime;
            yield return null;
        }

        Destroy(_object);
    }
}
