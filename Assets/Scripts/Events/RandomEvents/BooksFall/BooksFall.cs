using UnityEngine;

public class BooksFall : RandomEvent
{
    [SerializeField] private Animator _animator;

    public override void Happen()
    {
        _animator.Play(ShelfAnimator.Animation.FallBooks);
    }
}
