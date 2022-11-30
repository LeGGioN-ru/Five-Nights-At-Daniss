using UnityEngine;

public class SeriosDanis : Danis
{
    [SerializeField] private float _runAwayDelay;
    [SerializeField] private float _needApplyAttack;

    protected override bool ConditionAttack()
    {
        if (ApliedDoor + ApliedLight >= _needApplyAttack)
        {
            return true;
        }

        return false;
    }

    protected override bool ConditionRanAway()
    {
        if (PassedTime >= _runAwayDelay)
        {
            return true;
        }

        return false;
    }
}
