using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigidbody;
    
    // Movement-related
    private float _movementX;
    private float _movementY;
    public float speed = 5;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        
    }

    void OnMove(InputValue movementValue)
    {
        _movementX = movementValue.Get<Vector2>().x;
        _movementY = movementValue.Get<Vector2>().y;
    }
    void FixedUpdate()
    {
        // Create a 3D movement vector using the X and Y inputs.
        Vector3 movement = new Vector3 (_movementX, 0.0f, _movementY) * speed;
        _rigidbody.linearVelocity = movement;

        
    }
}
