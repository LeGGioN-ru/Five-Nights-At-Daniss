using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarIncarnate : DialogueEvent
{
    [SerializeField] private Truck _truck;

    public override void Happen()
    {
        _truck.gameObject.SetActive(true);
    }
}
