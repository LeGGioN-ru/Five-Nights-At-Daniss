using UnityEngine;

public class BadEyesDanis : Danis
{
    [SerializeField] private float _needAttackLightAplied;
    [SerializeField] private float _ranAwayDelay;

    private void Start()
    {
        UpHeartBeat(_ranAwayDelay);
    }

    protected override bool ConditionAttack()
    {
        if (_needAttackLightAplied <= ApliedLight)
        {
            return true;
        }

        return false;
    }

    protected override bool ConditionRanAway()
    {
        if (PassedTime >= _ranAwayDelay)
        {
            return true;
        }

        return false;
    }
}
