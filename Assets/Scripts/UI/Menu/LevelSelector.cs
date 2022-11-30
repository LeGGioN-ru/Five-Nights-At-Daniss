using IJunior.TypedScenes;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    [SerializeField] private GameObject _levelSelector;
    [SerializeField] private GameObject _mainButtonsPanel;

    [SerializeField] private Button _back;
    [SerializeField] private Button _firstLevel;
    [SerializeField] private Button _secondLevel;
    [SerializeField] private Button _thirdLevel;
    [SerializeField] private Button _fourthLevel;
    [SerializeField] private Button _fiveLevel;
    [SerializeField] private Button _endLevel;

    public event UnityAction SceneLoaded;

    private void OnEnable()
    {
        DefineAvalibleLevels();
        _back.onClick.AddListener(OnBackButtonClick);
        _firstLevel.onClick.AddListener(OnFirstLevelClick);
        _secondLevel.onClick.AddListener(OnSecondLevelClick);
        _thirdLevel.onClick.AddListener(OnThirdLevelClick);
        _fourthLevel.onClick.AddListener(OnFourthLevelClick);
        _fiveLevel.onClick.AddListener(OnFiveLevelClick);
        _endLevel.onClick.AddListener(OnEndLevelClick);
    }

    private void OnDisable()
    {
        _back.onClick.RemoveListener(OnBackButtonClick);
        _firstLevel.onClick.RemoveListener(OnFirstLevelClick);
        _secondLevel.onClick.RemoveListener(OnSecondLevelClick);
        _thirdLevel.onClick.RemoveListener(OnThirdLevelClick);
        _fourthLevel.onClick.RemoveListener(OnFourthLevelClick);
        _fiveLevel.onClick.RemoveListener(OnFiveLevelClick);
        _endLevel.onClick.RemoveListener(OnEndLevelClick);
    }

    private void OnFirstLevelClick()
    {
        SceneLoaded?.Invoke();
        Night_1.Load();
    }

    private void OnSecondLevelClick()
    {
        SceneLoaded?.Invoke();
        Night_2.Load();
    }

    private void OnThirdLevelClick()
    {
        SceneLoaded?.Invoke();
        Night_3.Load();
    }

    private void OnFourthLevelClick()
    {
        SceneLoaded?.Invoke();
        Night_4.Load();
    }

    private void OnFiveLevelClick()
    {
        SceneLoaded?.Invoke();
        Night_5.Load();
    }

    private void OnEndLevelClick()
    {
        SceneLoaded?.Invoke();
        EndRoom.Load();
    }

    private void OnBackButtonClick()
    {
        _levelSelector.SetActive(false);
        _mainButtonsPanel.SetActive(true);
    }

    private void DefineAvalibleLevels()
    {
        var save = SaveChecker.TryGetSaveFile();

        Button[] levelButtons = new Button[] { _firstLevel, _secondLevel, _thirdLevel, _fourthLevel, _fiveLevel, _endLevel };

        for (int i = 0; i < save.LevelConfigurations.Count; i++)
        {
            if (save.LevelConfigurations[i].IsPass)
            {
                if (i + 1 <= levelButtons.Length - 1)
                {
                    levelButtons[i + 1].interactable = true;
                }
            }
        }
    }
}
