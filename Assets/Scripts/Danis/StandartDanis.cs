using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandartDanis : Danis
{
    protected override bool ConditionAttack()
    {
        if (ApliedDoor == -1)
        {
            return true;
        }

        return false;
    }

    protected override bool ConditionRanAway()
    {
        if (ApliedDoor >= 5)
        {
            return true;
        }

        return false;
    }
}
