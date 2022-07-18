using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonSelector : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    public bool IsSelected { get; private set; }

    public void OnDeselect(BaseEventData eventData)
    {
        IsSelected = false;
    }

    public void OnSelect(BaseEventData eventData)
    {
        IsSelected = true;
    }
}
