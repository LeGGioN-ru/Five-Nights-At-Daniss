using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

[RequireComponent(typeof(SpriteRenderer))]
public abstract class Danis : MonoBehaviour
{
    [SerializeField] private float _amountAddDoorLightTable;
    [SerializeField] private float _conditionCheckDelay;
    [SerializeField] private AudioSource _detectSound;
    [SerializeField] private AudioSource _heartBeat;
    [SerializeField] private float _percentRanAway;
    [SerializeField] private float _timeToRunAway;

    protected float ApliedLight;
    protected float ApliedDoor;
    protected float ApliedTable;
    protected bool IsLeftSide;
    protected bool IsConditionCompleting;
    protected float PassedTime;

    public event UnityAction<Danis> RanedAway;
    public event UnityAction<Danis> Attacked;

    private bool _isDetected;
    private float _tempDoorAplied;
    private float _tempLightAplied;
    private float _tempTableAplied;
    private SpriteRenderer _spriteRenderer;
    private bool _isHidden;
    private Door[] _doors;
    private WallLight[] _wallLights;

    protected bool IsNeedHeartBeat = true;

    [ContextMenu("Set Default Settings")]
    private void SetDefaultSettings()
    {
        _amountAddDoorLightTable = 1;
        _conditionCheckDelay = 0.4f;
        _percentRanAway = 0.1f;
        _timeToRunAway = 1;
    }

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        Hide(IsLeftSide);
    }

    private void OnDisable()
    {
        foreach (var door in _doors)
        {
            door.Ticked -= OnDoorTicked;
        }

        foreach (var light in _wallLights)
        {
            light.Ticked -= OnLightTicked;
            light.Ticked -= Incarnate;
        }
    }

    protected virtual void Update()
    {
        if (ConditionRanAway())
        {
            RanAway();
        }
        else if (ConditionAttack())
        {
            Attack();
        }

        if (IsConditionCompleting == false)
        {
            PassedTime += Time.deltaTime;
        }
    }

    public void Init(bool isLeftSide, Door[] doors, WallLight[] lights, Table table, Player player)
    {
        IsLeftSide = isLeftSide;
        _doors = doors;
        _wallLights = lights;

        _spriteRenderer.gameObject.transform.LookAt(player.transform);

        foreach (var door in _doors)
        {
            door.Ticked += OnDoorTicked;
        }

        foreach (var light in _wallLights)
        {
            light.Ticked += OnLightTicked;
            light.Ticked += Incarnate;
            light.Disabled += Hide;
        }

        table.Ticked += OnTableTick;
    }

    protected void Attack()
    {
        Attacked?.Invoke(this);
    }

    protected void RanAway()
    {
        StartCoroutine(HideAway());
        RanedAway?.Invoke(this);
    }

    protected abstract bool ConditionRanAway();

    protected abstract bool ConditionAttack();

    protected virtual void OnLightTicked(bool isLeftDoor)
    {
        if (isLeftDoor == IsLeftSide)
            ApliedLight += _amountAddDoorLightTable;
    }

    protected virtual void OnDoorTicked(bool isLeftDoor)
    {
        if (isLeftDoor == IsLeftSide)
            ApliedDoor += _amountAddDoorLightTable;
    }

    protected IEnumerator DoorConditionCompliting()
    {
        while (true)
        {
            IsConditionCompleting = _tempDoorAplied != ApliedDoor;

            _tempDoorAplied = ApliedDoor;
            yield return new WaitForSeconds(_conditionCheckDelay);
        }
    }

    protected void UpHeartBeat(float value)
    {
        _heartBeat.DOPitch(AudioSourse.MaxPitch, value);
    }

    protected IEnumerator LightConditionCompliting()
    {
        while (true)
        {
            IsConditionCompleting = _tempLightAplied != ApliedLight;

            _tempLightAplied = ApliedLight;
            yield return new WaitForSeconds(_conditionCheckDelay);
        }
    }

    protected IEnumerator TableConditionCompliting()
    {
        while (true)
        {
            IsConditionCompleting = _tempTableAplied != ApliedTable;

            _tempTableAplied = ApliedTable;
            yield return new WaitForSeconds(_conditionCheckDelay);
        }
    }

    private void OnTableTick()
    {
        ApliedTable += _amountAddDoorLightTable;
    }

    private void Incarnate(bool isLeftLight)
    {
        if (_isDetected == false && isLeftLight == IsLeftSide)
        {
            _isDetected = true;
            _detectSound.Play();

            if (IsNeedHeartBeat == true)
            {
                _heartBeat.Play();
            }
        }

        if (IsLeftSide == isLeftLight && _isHidden == true)
        {
            _spriteRenderer.color = new Color(_spriteRenderer.color.r, _spriteRenderer.color.g, _spriteRenderer.color.b, 255);
            _isHidden = false;
        }
    }

    private void Hide(bool isLeftLight)
    {
        if (IsLeftSide == isLeftLight && _isHidden == false && _spriteRenderer != null)
        {
            _spriteRenderer.color = new Color(_spriteRenderer.color.r, _spriteRenderer.color.g, _spriteRenderer.color.b, 0);
            _isHidden = true;
        }
    }

    private IEnumerator HideAway()
    {
        float passedTime = 0;

        var transcpanent = new Color(_spriteRenderer.color.r, _spriteRenderer.color.g, _spriteRenderer.color.b, 0);

        while (passedTime < _timeToRunAway)
        {
            passedTime += Time.deltaTime;
            _spriteRenderer.color = Color.Lerp(_spriteRenderer.color, transcpanent, _percentRanAway * Time.deltaTime);
            _heartBeat.volume = Mathf.Lerp(_heartBeat.volume, 0, _percentRanAway * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }

        Destroy(gameObject);
    }
}