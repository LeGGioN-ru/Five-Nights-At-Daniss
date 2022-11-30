public class LevelConfiguration
{
    public bool IsPass { get; private set; }
    public bool IsPuareCollect { get; private set; }
    public int LevelNumber { get; private set; }

    public LevelConfiguration(bool isPass, bool isPuareCollect, int levelNumber)
    {
        IsPass = isPass;
        IsPuareCollect = isPuareCollect;
        LevelNumber = levelNumber;
    }
}
