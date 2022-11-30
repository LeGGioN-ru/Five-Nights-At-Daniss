using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class RedLamp : RandomEvent
{
    [SerializeField] private Light _lampLight;
    [SerializeField] private float _tickBroking;
    [SerializeField] private float _tickTime;
    [SerializeField] private float _minIntensivity;
    [SerializeField] private float _maxIntensivity;
    [SerializeField] private AudioSource _sound;

    public event UnityAction Ended;

    public override void Happen()
    {
        _sound.Play();
        StartCoroutine(BrokeLight());
    }

    private IEnumerator BrokeLight()
    {
        float passedTick = 0;

        while (passedTick < _tickBroking)
        {
            passedTick++;
            _lampLight.intensity = Random.Range(_minIntensivity, _maxIntensivity);
            yield return new WaitForSeconds(_tickTime);
        }

        Ended?.Invoke();
        _lampLight.color = Color.red;
    }
}
