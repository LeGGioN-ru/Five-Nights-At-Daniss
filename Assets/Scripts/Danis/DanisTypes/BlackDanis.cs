using UnityEngine;

public class BlackDanis : Danis
{
    [SerializeField] private float _needApplyLight;
    [SerializeField] private float _attackDelay;

    private void Start()
    {
        IsNeedHeartBeat = false;
        StartCoroutine(LightConditionCompliting());
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
        if (ApliedLight >= _needApplyLight)
        {
            return true;
        }

        return false;
    }
}

