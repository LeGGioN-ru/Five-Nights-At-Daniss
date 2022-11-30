using UnityEngine;

public class StandartDanis : Danis
{
    [SerializeField] private float _attackDelay;
    [SerializeField] private float _needDoorAplied;

    private float _passedTime;

    private void Start()
    {
        StartCoroutine(DoorConditionCompliting());
        UpHeartBeat(_attackDelay);
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
        if (ApliedDoor >= _needDoorAplied)
        {
            return true;
        }

        return false;
    }
}
