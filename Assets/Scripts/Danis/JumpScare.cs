using UnityEngine;
using UnityEngine.Video;
using DG.Tweening;
using System.Threading.Tasks;
using System;
using IJunior.TypedScenes;
using UnityEngine.Events;

public class JumpScare : MonoBehaviour
{
    [SerializeField] private VideoPlayer[] _screamers;
    [SerializeField] private VideoPlayer _puareAttackScreamer;
    [SerializeField] private GameObject _screamer;
    [SerializeField] private float _shakeTime;
    [SerializeField] private PuareAttack _puareAttack;
    [SerializeField] private float _iteration;

    public event UnityAction Executed;
    public event UnityAction Started;

    private void OnEnable()
    {
        _puareAttack.PatienceEnded += Execute;
    }

    private void OnDisable()
    {
        _puareAttack.PatienceEnded -= Execute;
    }

    public void Init(Danis danis)
    {
        danis.Attacked += OnAttack;
    }

    private async void Execute(bool isPuareAttack = false)
    {
        _screamer.SetActive(true);
        Started?.Invoke();
        VideoPlayer screamer;

        if (isPuareAttack)
        {
            screamer = _puareAttackScreamer;
        }
        else
        {
            screamer = _screamers[UnityEngine.Random.Range(0, _screamers.Length)];
        }

        screamer.Play();
        Camera.main.DOShakeRotation(_shakeTime);
        await Task.Delay(Convert.ToInt32(Convert.ToInt32(screamer.clip.length) * 1000 * _iteration));

        Executed?.Invoke();
        MainMenu.Load(new LevelConfiguration(false, false, 0));
    }

    private void OnAttack(Danis danis)
    {
        Execute();
        danis.Attacked -= OnAttack;
    }
}
