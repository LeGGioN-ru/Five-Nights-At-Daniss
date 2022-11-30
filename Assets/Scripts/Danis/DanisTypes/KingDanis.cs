using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingDanis : Danis
{
    [SerializeField] private float _needDoorAplied;
    [SerializeField] private float _needLightAplied;
    [SerializeField] private float _needTableAplied;
    [SerializeField] private float _attackDelay;

    private void Start()
    {
        StartCoroutine(DoorConditionCompliting());
        StartCoroutine(LightConditionCompliting());
        StartCoroutine(TableConditionCompliting());
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
        if (ApliedDoor >= _needDoorAplied && ApliedLight >= _needLightAplied && ApliedTable >= _needTableAplied)
        {
            return true;
        }

        return false;
    }
}
