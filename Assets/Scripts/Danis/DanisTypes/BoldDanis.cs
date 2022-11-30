using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoldDanis : Danis
{
    [SerializeField] private float _needApplyLight;
    [SerializeField] private float _needApplyTable;
    [SerializeField] private float _attackDelay;
    [SerializeField] private float _needAttackDoor;

    private void Start()
    {
        UpHeartBeat(_attackDelay);
        StartCoroutine(LightConditionCompliting());
        StartCoroutine(TableConditionCompliting());
    }

    protected override bool ConditionAttack()
    {
        if (PassedTime >= _attackDelay || ApliedDoor >= _needAttackDoor)
        {
            return true;
        }

        return false;
    }

    protected override bool ConditionRanAway()
    {
        if (ApliedLight >= _needApplyLight && ApliedTable >= _needApplyTable)
        {
            return true;
        }

        return false;
    }
}
