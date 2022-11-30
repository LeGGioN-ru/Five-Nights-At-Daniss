using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMoverActivator : MonoBehaviour
{
    [SerializeField] private PlayerMover _mover;
    [SerializeField] private TMP_Text _text;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            _mover.enabled = true;
            _text.text = "Выйдите из дома через дверь";
            Destroy(this);
        }
    }
}
