using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

public class PlayerSaveFile
{
    public List<LevelConfiguration> LevelConfigurations = new List<LevelConfiguration>();

    public int AmountLevels = 5;
    public float Volume = 0;
    public bool IsGoodEndGot;

    private string path = $"{Environment.CurrentDirectory}\\Save.json";

    public void Initialize()
    {
        for (int i = 0; i < AmountLevels; i++)
        {
            LevelConfigurations.Add(new LevelConfiguration(false, false, i));
        }
    }

    public LevelConfiguration GetItem(int index)
    {
        if (index <= LevelConfigurations.Count - 1)
        {
            return LevelConfigurations[index];
        }

        return null;
    }

    public void SaveData(LevelConfiguration levelConfiguration)
    {
        LevelConfigurations[levelConfiguration.LevelNumber] = levelConfiguration;

        RewriteSave();
    }

    public void SaveData()
    {
        RewriteSave();
    }

    public void ChageVolume(float value)
    {
        Volume = value;

        RewriteSave();
    }

    private void RewriteSave()
    {
        var serilizable = JsonConvert.SerializeObject(this);

        if (File.Exists(path))
        {
            File.WriteAllText(path, serilizable);
        }
    }

    public void GotGoodEnd()
    {
        IsGoodEndGot = true;
    }
}