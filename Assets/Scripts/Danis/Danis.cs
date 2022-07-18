using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public abstract class Danis : MonoBehaviour
{
    [SerializeField] private int _addLightDoorDelay;
    [SerializeField] private float _amountAddDoorLight;

    protected float ApliedLight;
    protected float ApliedDoor;
    protected bool IsLeftSide;

    public event UnityAction<Danis> RanedAway;

    private Door[] _doors;
    private WallLight[] _wallLights;
    private Coroutine _lightCoroutine;
    private Coroutine _doorCoroutine;

    private void OnDisable()
    {
        foreach (var door in _doors)
        {
            door.Opened -= OnDoorOpened;
            door.Closed -= OnDoorClosed;
        }

        foreach (var light in _wallLights)
        {
            light.Enabled -= OnLightEnabled;
            light.Disabled -= OnLightDisabled;
        }
    }

    private void Update()
    {
        if (ConditionRanAway())
        {
            RanAway();
        }
        else if (ConditionAttack())
        {
            Attack();
        }
    }

    private void OnLightEnabled(bool isLeftSide)
    {
        if (isLeftSide == IsLeftSide)
        {
            _lightCoroutine = StartCoroutine(AddLight());
        }
    }

    private void OnLightDisabled(bool isLeftSide)
    {
        if (isLeftSide == IsLeftSide && _lightCoroutine != null)
        {
            StopCoroutine(_lightCoroutine);
        }
    }

    private void OnDoorOpened(bool isLeftSide)
    {
        if (isLeftSide == IsLeftSide && _doorCoroutine != null)
        {
            StopCoroutine(_doorCoroutine);
        }
    }

    private void OnDoorClosed(bool isLeftSide)
    {
        if (isLeftSide == IsLeftSide)
        {
            _doorCoroutine = StartCoroutine(AddDoor());
        }
    }

    private IEnumerator AddLight()
    {
        while (true)
        {
            ApliedLight += _amountAddDoorLight;
            yield return new WaitForSeconds(_addLightDoorDelay);
        }
    }

    private IEnumerator AddDoor()
    {
        while (true)
        {
            ApliedDoor += _amountAddDoorLight;
            yield return new WaitForSeconds(_addLightDoorDelay);
        }
    }

    public void Init(bool isLeftSide, Door[] doors, WallLight[] lights)
    {
        IsLeftSide = isLeftSide;
        _doors = doors;
        _wallLights = lights;

        foreach (var door in _doors)
        {
            door.Opened += OnDoorOpened;
            door.Closed += OnDoorClosed;
        }

        foreach (var light in _wallLights)
        {
            light.Enabled += OnLightEnabled;
            light.Disabled += OnLightDisabled;
        }
    }

    protected void Attack()
    {
        Debug.Log("attack");
    }

    protected void RanAway()
    {
        Debug.Log("runned away");
        RanedAway?.Invoke(this);
        Destroy(gameObject);
    }

    protected abstract bool ConditionRanAway();

    protected abstract bool ConditionAttack();
}
