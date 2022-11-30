using UnityEngine;

public class BlatnoiDanis : Danis
{
    [SerializeField] private float _needTableApplied;
    [SerializeField] private float _attackDelay;
    [SerializeField] private float _attackLightDoorNeed;

    private void Start()
    {
        StartCoroutine(TableConditionCompliting());
        UpHeartBeat(_attackDelay);
    }

    protected override bool ConditionAttack()
    {
        if (PassedTime >= _attackDelay || ApliedDoor + ApliedLight >= _attackLightDoorNeed)
        {
            return true;
        }

        return false;
    }

    protected override bool ConditionRanAway()
    {
        if (ApliedTable >= _needTableApplied)
        {
            return true;
        }

        return false;
    }
}
