using UnityEngine;
using UnityEngine.UI;

public class DanispediaUI : MonoBehaviour
{
    [SerializeField] private Button[] _closeButtons;
    [SerializeField] private Danispedia _danisPedia;
    [SerializeField] private DanisArticle[] _danisArticles;

    private void OnEnable()
    {
        DefineOpenedArticles();

        foreach (var button in _closeButtons)
        {
            button.onClick.AddListener(OnCloseButtonClick);
        }
    }

    private void OnDisable()
    {
        foreach (var button in _closeButtons)
        {
            button.onClick.RemoveListener(OnCloseButtonClick);
        }
    }

    private void DefineOpenedArticles()
    {
        var save = SaveChecker.TryGetSaveFile();

        _danisArticles[0].gameObject.SetActive(true);
        _danisArticles[1].gameObject.SetActive(true);

        for (int i = 1; i < save.LevelConfigurations.Count; i++)
        {
            if (save.LevelConfigurations[i].IsPass)
            {
                _danisArticles[i * 2].gameObject.SetActive(true);
                _danisArticles[i * 2 + 1].gameObject.SetActive(true);
            }
        }
    }

    private void OnCloseButtonClick()
    {
        _danisPedia.gameObject.SetActive(false);
    }
}
