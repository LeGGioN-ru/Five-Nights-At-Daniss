using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    [SerializeField] private Button _startCameraSelected;

    private void Start()
    {
        _startCameraSelected.Select();
    }
}
