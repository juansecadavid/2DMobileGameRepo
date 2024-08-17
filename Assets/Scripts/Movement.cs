using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;

    [SerializeField] private float _movementSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _rigidbody2D.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * _movementSpeed, _rigidbody2D.velocity.y);
        Debug.Log(Input.GetAxisRaw("Horizontal"));
    }
}
