using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Room))]
[RequireComponent(typeof(Button))]
[RequireComponent(typeof(ButtonSelector))]
public class RoomRenderer : MonoBehaviour
{
    [SerializeField] private Image _roomImage;

    private Room _room;
    private Button _button;
    private ButtonSelector _buttonSelector;

    private void Awake()
    {
        _room = GetComponent<Room>();
        _button = GetComponent<Button>();
        _buttonSelector = GetComponent<ButtonSelector>();
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
        if (_buttonSelector.IsSelected)
        {
            SetImage();
        }
    }

    private void SetImage()
    {
        _roomImage.sprite = _room.GetCurrentPhoto();
    }
}
