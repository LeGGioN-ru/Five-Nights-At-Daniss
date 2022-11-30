public class EndGamePlayerLookerSwitcher : PlayerLookerSwitcher
{
    protected override void OnEnable()
    {
        Inputer.Opened += Disable;
        Inputer.Closed += Enable;
    }

    protected override void OnDisable()
    {
        Inputer.Opened -= Disable;
        Inputer.Closed -= Enable;
    }
}
