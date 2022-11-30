using Newtonsoft.Json;
using System;
using System.IO;

public static class SaveChecker
{
    public static PlayerSaveFile TryGetSaveFile()
    {
        string path = $"{Environment.CurrentDirectory}\\Save.json";

        try
        {
            if (File.Exists(path))
            {
                return JsonConvert.DeserializeObject<PlayerSaveFile>(File.ReadAllText(path));
            }

            return CreateNewFile(path);
        }
        catch
        {
            File.Delete(path);
            return CreateNewFile(path);
        }
    }

    private static PlayerSaveFile CreateNewFile(string path)
    {
        File.Create(path).Dispose();

        var save = new PlayerSaveFile();
        save.Initialize();

        var serilizable = JsonConvert.SerializeObject(save);

        if (File.Exists(path))
        {
            File.WriteAllText(path, serilizable);
        }

        return JsonConvert.DeserializeObject<PlayerSaveFile>(serilizable);
    }
}
