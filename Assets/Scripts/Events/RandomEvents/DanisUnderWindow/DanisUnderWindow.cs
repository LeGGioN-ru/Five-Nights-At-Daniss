using UnityEngine;

public class DanisUnderWindow : RandomEvent
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private DanisDetector _template;
    [SerializeField] private Transform _endPoint;

    public override void Happen()
    {
        Instantiate(_template, _spawnPoint).Init(_endPoint);
    }
}
