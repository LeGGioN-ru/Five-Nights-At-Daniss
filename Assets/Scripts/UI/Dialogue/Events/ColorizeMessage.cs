using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ColorizeMessage : DialogueEvent
{
    [SerializeField] private Color _color;
    [SerializeField] private TMP_Text _text;

    public override void Happen()
    {
        _text.color = _color;
    }
}
