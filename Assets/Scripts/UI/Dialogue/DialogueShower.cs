using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class DialogueShower : MonoBehaviour
{
    [SerializeField] private List<Dialogue> _dialogues = new List<Dialogue>();
    [SerializeField] private float _dialogShowSpeed;
    [SerializeField] private TMP_Text _textDialoge;
    [SerializeField] private TMP_Text _textName;
    [SerializeField] private GameObject _stopPanel;

    [SerializeField] private Color _danisNameColor;
    [SerializeField] private Color _enviromenColor;
    [SerializeField] private Color _unnamedColor;

    public UnityAction DialogesEnded;
    public UnityAction<string, string> PhraseSayed;

    private Coroutine _dialogTyping;
    private string _currentPhrase;
    private int _currentDialogeIndex;

    private void OnEnable()
    {
        TryTypeNextPhrase();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _stopPanel.activeSelf == false)
        {
            if (_dialogTyping == null)
            {
                TryTypeNextPhrase();
                return;
            }

            SkipTyping();
        }
    }

    private void StopType()
    {
        StopCoroutine(_dialogTyping);
        _dialogTyping = null;
        _textDialoge.text = string.Empty;
    }

    private void SkipTyping()
    {
        if (_dialogues[_currentDialogeIndex].IsFastSkip)
        {
            return;
        }

        StopType();

        _textDialoge.text = _currentPhrase;
    }

    private IEnumerator TypeDialog(string phrase)
    {
        foreach (var symbol in phrase)
        {
            _textDialoge.text += symbol;
            yield return new WaitForSeconds(_dialogShowSpeed);
        }

        _dialogTyping = null;

        if (_dialogues[_currentDialogeIndex].IsFastSkip)
        {
            TryTypeNextPhrase();
        }
    }

    private void TryTypeNextPhrase()
    {
        if (_dialogues.Count <= _currentDialogeIndex)
        {
            DialogesEnded?.Invoke();
            enabled = false;
            return;
        }

        if (_dialogues[_currentDialogeIndex].TryGetNextPharase(out string phrase))
        {
            TypePhrase(phrase);
            PhraseSayed?.Invoke(_dialogues[_currentDialogeIndex].Name, phrase);
            return;
        }

        if (_dialogues.Count >= _currentDialogeIndex)
        {
            _currentDialogeIndex++;
            TryTypeNextPhrase();
            return;
        }
    }

    private void TypePhrase(string phrase)
    {
        _textDialoge.text = string.Empty;
        _textDialoge.color = Color.white;
        _textName.text = _dialogues[_currentDialogeIndex].Name;
        _textName.color = DefineColorName(_dialogues[_currentDialogeIndex].Name);
        _currentPhrase = phrase;
        _dialogTyping = StartCoroutine(TypeDialog(phrase));
    }

    private Color DefineColorName(string name)
    {
        switch (name)
        {
            case DialogNames.Danis:
                return _danisNameColor;
            case DialogNames.Enviroment:
                return _enviromenColor;
            case DialogNames.Unnamed:
                return _unnamedColor;

            default:
                return Color.white;
        }
    }
}
