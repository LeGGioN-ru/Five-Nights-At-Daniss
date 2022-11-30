using UnityEngine;

public class Photo : DialogueEvent
{
    [SerializeField] private GameObject _flash;

    public override void Happen()
    {
        _flash.SetActive(true);
    }
}
