using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private Transform EndPoint;
    [SerializeField] private float _movementSpeed;
    private bool _canChange = true;
    private float _directionMagnitude;
    private Vector2 StartPoint;
    
    // Start is called before the first frame update
    void Start()
    {
        Vector2 adjustedVector = new Vector2(transform.position.x + 0.3f, transform.position.y);
        StartPoint = adjustedVector;
        _directionMagnitude = -Mathf.Sign(EndPoint.position.x);
        Debug.Log(_directionMagnitude);
        StartCoroutine(CanChangeDirectionCoolDown());
    }
    
    // Update is called once per frame
    private void Update()
    {
        if ( _canChange && (Vector2.Distance(_rigidbody2D.position, EndPoint.position) < 0.1 || Vector2.Distance(_rigidbody2D.position, StartPoint) < 0.1))
        {
            StartCoroutine(CanChangeDirectionCoolDown());
        }
    }

    void FixedUpdate()
    {
        _rigidbody2D.velocity = new Vector2(_directionMagnitude * _movementSpeed, _rigidbody2D.velocity.y);
    }

    IEnumerator CanChangeDirectionCoolDown()
    {
        _directionMagnitude = -1*_directionMagnitude;
        _canChange = false;
        yield return new WaitForSecondsRealtime(0.1f);
        _canChange = true;
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Movement>().MoveOverride(_directionMagnitude, _movementSpeed);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Movement>().ResetMovement();
        }
    }
}
