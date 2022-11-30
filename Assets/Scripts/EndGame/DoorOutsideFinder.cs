using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOutsideFinder : MonoBehaviour
{
    [SerializeField] private ObjectFinder _finder;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_finder.TryFindObject(out DoorOutside door))
            {
                door.Exit();
            }
        }
    }
}
