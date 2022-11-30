using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorUnlocker : MonoBehaviour
{
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
