using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public static class Axis
{
    public static class MouseAxis
    {
        public const string MouseX = "Mouse X";
        public const string MouseY = "Mouse Y";
    }

    public static class KeyboardAxis
    {
        public const string Horizontal = nameof(Horizontal);
        public const string Vertical = nameof(Vertical);
    }
}
