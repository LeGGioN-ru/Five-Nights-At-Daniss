using UnityEngine;

public class SecretPhotoRoom : Room
{
    [SerializeField] private float _dropChance;
    [SerializeField] private Sprite _secretPhoto;

    public override Sprite GetCurrentPhoto()
    {
        if (IsDanisHere && _dropChance >= Random.Range(0, 100))
        {
            return _secretPhoto;
        }

        return base.GetCurrentPhoto();
    }
}
