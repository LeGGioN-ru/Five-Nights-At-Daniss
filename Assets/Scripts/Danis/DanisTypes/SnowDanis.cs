using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowDanis : Danis
{
    [SerializeField] private float _needDoorAplied;
    [SerializeField] private float _attackDelay;

    private void Start()
    {
        IsNeedHeartBeat = false;
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
        if (ApliedDoor >= _needDoorAplied)
        {
            return true;
        }

        return false;
    }
}
