using IJunior.TypedScenes;
using UnityEngine;

public class MainMenuAccepter : MonoBehaviour, ISceneLoadHandler<LevelConfiguration>
{
    public void OnSceneLoaded(LevelConfiguration levelConfiguration)
    {
        var saveFile = SaveChecker.TryGetSaveFile();

        var currentLevelConfig = saveFile.GetItem(levelConfiguration.LevelNumber);

        if (levelConfiguration.IsPass == false)
        {
            return;
        }

        if (currentLevelConfig.IsPuareCollect)
        {
            return;
        }

        saveFile.SaveData(levelConfiguration);
    }
}
