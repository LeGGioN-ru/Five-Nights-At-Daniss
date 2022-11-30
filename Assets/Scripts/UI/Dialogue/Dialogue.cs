using System;
using UnityEditor;
using UnityEngine;

[Serializable]
public class Dialogue
{
    [SerializeField] private string _name;
    [SerializeField] private string[] _phrases;
    [SerializeField] private string _specialSymbol;
    [SerializeField] private bool _isFastSkip;

    private string _playerName;

    public bool IsFastSkip => _isFastSkip;
    public string Name => _name;

    private int _currentIndex;

    public virtual bool TryGetNextPharase(out string phrase)
    {
        if (_phrases.Length - 1 >= _currentIndex)
        {
            phrase = _phrases[_currentIndex];

            if (_specialSymbol != string.Empty)
            {
                _playerName = Environment.UserName;
                phrase = phrase.Replace(_specialSymbol, _playerName);
            }

            _currentIndex++;
            return true;
        }

        phrase = string.Empty;
        return false;
    }
}
