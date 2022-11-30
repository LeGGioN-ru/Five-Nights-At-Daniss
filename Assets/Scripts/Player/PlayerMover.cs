using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _walkSpeed;
    [SerializeField] private float _gravity;

    private CharacterController _controller;
    private float _velocityY = 0f;

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Vector2 inputDirection = new Vector2(Input.GetAxisRaw(Axis.KeyboardAxis.Horizontal), Input.GetAxisRaw(Axis.KeyboardAxis.Vertical));
        inputDirection.Normalize();

        if (_controller.isGrounded)
            _velocityY = 0;

        _velocityY += _gravity * Time.deltaTime;

        Vector3 velocity = (transform.forward * inputDirection.y + transform.right * inputDirection.x) * _walkSpeed + Vector3.up * _velocityY;

        _controller.Move(velocity * Time.deltaTime);
    }
}
