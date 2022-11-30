using UnityEngine;

public class RainDanis : Danis
{
    [SerializeField] private float _attackDelay;
    [SerializeField] private float _needDoorApplied;
    [SerializeField] private float _needLighteApplied;

    private void Start()
    {
        UpHeartBeat(_attackDelay);
        StartCoroutine(DoorConditionCompliting());
    }

    protected override bool ConditionAttack()
    {
        if (PassedTime >= _attackDelay)
        {
            return true;
        }

        return false;
    }

    protected override bool ConditionRanAway()
    {
        if (ApliedDoor >= _needDoorApplied && ApliedLight >= _needLighteApplied)
        {
            return true;
        }

        return false;
    }
}
