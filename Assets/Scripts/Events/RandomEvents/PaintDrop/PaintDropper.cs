using UnityEngine;

public class PaintDropper : RandomEvent
{
    [SerializeField] private Animator _paintController;

    public override void Happen()
    {
        _paintController.Play(PaintController.Animation.PaintDrop);
    }
}
