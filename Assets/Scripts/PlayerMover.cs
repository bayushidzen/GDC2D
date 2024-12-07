using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    private const float speedBooster = 20f;
    [SerializeField] private float _speedX = 0.5f;
    private Rigidbody2D _rigidbody;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector2(_speedX * speedBooster * Time.fixedDeltaTime, _rigidbody.velocity.y);
        
    }
}
