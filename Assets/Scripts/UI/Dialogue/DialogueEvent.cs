using UnityEngine;

[RequireComponent(typeof(DialogueShower))]
public abstract class DialogueEvent : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private string _phrase;

    private DialogueShower _shower;

    private void Awake()
    {
        _shower = GetComponent<DialogueShower>();
    }

    private void OnEnable()
    {
        _shower.PhraseSayed += OnNeedPhraseSay;
    }

    private void OnDisable()
    {
        _shower.PhraseSayed -= OnNeedPhraseSay;
    }

    private void OnNeedPhraseSay(string name, string phrase)
    {
        if (name == _name && phrase == _phrase)
        {
            Happen();
        }
    }

    public abstract void Happen();
}
