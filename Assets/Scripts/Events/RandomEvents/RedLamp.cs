using UnityEngine;

public class RedLamp : RandomEvent
{
    [SerializeField] private Light _lampLight;

    public override void Happen()
    {
        _lampLight.color = Color.red;
    }
}
