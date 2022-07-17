using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Room))]
[RequireComponent(typeof(Button))]
public class RoomRenderer : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    [SerializeField] private Image _roomImage;

    private Room _room;
    private Button _button;
    private bool _isSelected;

    private void Awake()
    {
        _room = GetComponent<Room>();
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _room.DanisMoved += UpdateImage;
        _button.onClick.AddListener(SetImage);
    }

    private void OnDisable()
    {
        _room.DanisMoved -= UpdateImage;
        _button.onClick.RemoveListener(SetImage);
    }

    private void UpdateImage()
    {
        if (_isSelected)
        {
            SetImage();
        }
    }

    private void SetImage()
    {
        _roomImage.sprite = _room.GetCurrentPhoto();
    }

    public void OnSelect(BaseEventData eventData)
    {
        _isSelected = true;
    }

    public void OnDeselect(BaseEventData eventData)
    {
        _isSelected = false;
    }
}
