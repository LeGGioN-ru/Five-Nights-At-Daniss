using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassDestroyer : MonoBehaviour
{
    [SerializeField] private GameObject _glass;

    public void BrokeGlass()
    {
        Destroy(_glass);
    }
}
