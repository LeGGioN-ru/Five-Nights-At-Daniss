using UnityEngine;
using UnityEngine.UI;

public class Danispedia : MonoBehaviour
{
    [SerializeField] private Scrollbar _scrollBar;
    [SerializeField] private MainMenuUI _mainMenu;

    private void OnEnable()
    {
        _mainMenu.DanispediaOpened += OnDanispediaOpen;
    }

    private void OnDisable()
    {
        _mainMenu.DanispediaOpened -= OnDanispediaOpen;
    }

    private void OnDanispediaOpen()
    {
        _scrollBar.value = 1;
    }
}
