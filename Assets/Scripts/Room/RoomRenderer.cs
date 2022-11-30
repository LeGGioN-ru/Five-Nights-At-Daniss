using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(ButtonSelector))]
public class RoomRenderer : MonoBehaviour
{
    [SerializeField] private Image _roomImage;
    [SerializeField] private Room _room;

    public event UnityAction ImageChanged;
    public event UnityAction<int> DanisesCome;
    public event UnityAction DanisesNotCome;

    private Button _button;
    private ButtonSelector _buttonSelector;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _buttonSelector = GetComponent<ButtonSelector>();
    }

    private void OnEnable()
    {
        _room.DanisMoved += CheckDopelganger;
        _room.DanisMoved += UpdateImage;
        _button.onClick.AddListener(CheckDopelganger);
        _button.onClick.AddListener(SetImage);
    }

    private void OnDisable()
    {
        _room.DanisMoved -= CheckDopelganger;
        _room.DanisMoved -= UpdateImage;
        _button.onClick.RemoveListener(CheckDopelganger);
        _button.onClick.RemoveListener(SetImage);
    }

    private void UpdateImage()
    {
        if (_buttonSelector.IsSelected)
        {
            SetImage();
        }
    }

    private void CheckDopelganger()
    {
        if (_room.DanisCount > 1 && _buttonSelector.IsSelected)
        {
            DanisesCome?.Invoke(_room.DanisCount);
            return;
        }

        DanisesNotCome?.Invoke();
    }

    private void SetImage()
    {
        if (_roomImage.sprite == _room.GetCurrentPhoto())
        {
            return;
        }

        ImageChanged?.Invoke();
        _roomImage.sprite = _room.GetCurrentPhoto();
    }
}
