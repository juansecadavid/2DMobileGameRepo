using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private float _jumpForce = 10f;
    [SerializeField] private float _startMovementSpeed;
    [SerializeField] private Joystick _joystick;
    private float _currentMovementSpeed;
    private bool canJump = true; 

    public float MovementDirection { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        _currentMovementSpeed = _startMovementSpeed;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        MovementDirection = _joystick.Direction.x;
        //_movementDirection = Input.GetAxisRaw("Horizontal");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _rigidbody2D.velocity = new Vector2(MovementDirection * _currentMovementSpeed, _rigidbody2D.velocity.y);
    }

    public void Jump()
    {
        //Debug.Log("Llamé a saltar");
        if (canJump)
        {
            _rigidbody2D.AddForce(new Vector2(0f, _jumpForce), ForceMode2D.Impulse);
            canJump = false;
        }
    }

    public void MoveOverride(float _directionMagnitude, float _speed)
    {
        MovementDirection = _directionMagnitude;
        _currentMovementSpeed = _speed;
    }
    
    public void ResetMovement()
    {
        _currentMovementSpeed = _startMovementSpeed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            canJump = true;
        }
    }
}
