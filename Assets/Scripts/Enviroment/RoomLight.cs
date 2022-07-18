using UnityEngine;

[RequireComponent(typeof(Light))]
public class RoomLight : MonoBehaviour
{
    [SerializeField] private Battery _battery;
    [SerializeField] private float _minLight;
    [SerializeField] private float _maxLight;

    private Light _light;

    private void Awake()
    {
        _light = GetComponent<Light>();
    }

    private void OnEnable()
    {
        _battery.Downed += OnDowned;
    }

    private void OnDisable()
    {
        _battery.Downed -= OnDowned;
    }

    private void OnDowned(float currentStock)
    {
        var actialLight = currentStock / 100 * _maxLight;
        _light.intensity = Mathf.Clamp(actialLight, _minLight, _maxLight);
    }
}
