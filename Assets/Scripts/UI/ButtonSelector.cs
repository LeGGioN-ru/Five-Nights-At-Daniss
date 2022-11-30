using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonSelector : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    public event UnityAction Selected;
    public event UnityAction DeSelected;

    public bool IsSelected { get; private set; }

    public void OnDeselect(BaseEventData eventData)
    {
        IsSelected = false;
        DeSelected?.Invoke();
    }

    public void OnSelect(BaseEventData eventData)
    {
        IsSelected = true;
        Selected?.Invoke();
    }
}
