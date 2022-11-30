using UnityEngine;

public class EventsActivatorSwitcher : MonoBehaviour
{
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private EventsActivator _eventsActivator;

    private void OnEnable()
    {
        _startScreen.Started += Disable;
        _startScreen.Ended += Enable;
    }

    private void OnDisable()
    {
        _startScreen.Started -= Disable;
        _startScreen.Ended -= Enable;
    }

    private void Enable()
    {
        _eventsActivator.enabled = true;
    }

    private void Disable()
    {
        _eventsActivator.enabled = false;
    }
}
