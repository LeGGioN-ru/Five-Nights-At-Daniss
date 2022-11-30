using UnityEngine;

public class SchoolBoyDanis : Danis
{
    [SerializeField] private float _attackDelay;
    [SerializeField] private float _needDoorApplied;
    [SerializeField] private float _needTableApplied;
    [SerializeField] private float _needAttackLight;

    private void Start()
    {
        UpHeartBeat(_attackDelay);
        StartCoroutine(TableConditionCompliting());
        StartCoroutine(DoorConditionCompliting());
    }

    protected override bool ConditionAttack()
    {
        if (PassedTime >= _attackDelay || ApliedLight >= _needAttackLight)
        {
            return true;
        }

        return false;
    }

    protected override bool ConditionRanAway()
    {
        if (ApliedDoor >= _needDoorApplied && ApliedTable >= _needTableApplied)
        {
            return true;
        }

        return false;
    }
}
