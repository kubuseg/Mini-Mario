using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private const int JumpForce = 5;
    private const int SidewayForce = 2;
    private bool _jumpPressed;
    private float _horizontalInput;
    [SerializeField] private Transform _groundCheckTransform;
    [SerializeField] private LayerMask _playerMask;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            _jumpPressed = true;
        _horizontalInput = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        if (Physics.OverlapSphere(_groundCheckTransform.position, 0.1f, _playerMask).Length != 0 && _jumpPressed)
        {
            _rigidbody.AddForce(Vector3.up * JumpForce, ForceMode.VelocityChange);
            _jumpPressed = false;
        }

        var velocity = _rigidbody.velocity;
        velocity = new Vector3(_horizontalInput * SidewayForce, velocity.y, velocity.z);
        _rigidbody.velocity = velocity;
    }

    
}
