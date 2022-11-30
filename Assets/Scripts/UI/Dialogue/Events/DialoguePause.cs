using System;
using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(DialogueShower))]
public class DialoguePause : DialogueEvent
{
    [SerializeField] private float _pauseDuration;

    private DialogueShower _dialogShower;

    private void Start()
    {
        _dialogShower = GetComponent<DialogueShower>();
    }

    public override async void Happen()
    {
        _dialogShower.gameObject.SetActive(false);

        await Task.Delay(Convert.ToInt32(_pauseDuration * 1000));

        _dialogShower.gameObject.SetActive(true);
    }
}
