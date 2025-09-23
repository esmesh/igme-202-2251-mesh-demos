using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;

public class PlayerController : MonoBehaviour
{
    [SerializeField, Range(1, 20)]
    private int speed = 5;

    [SerializeField]
    private Vector3 direction;

    [SerializeField]
    private Rigidbody2D rBody;

    // extra fields to allow debug in inspector
    [SerializeField]
    Vector3 velocity;

    [SerializeField]
    Vector3 position;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        velocity = direction * speed; // in units/second
        position = transform.position;

        // update position based on velocity FOR THE frame length
        position += velocity * Time.fixedDeltaTime;

        rBody.MovePosition(position);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        direction = context.ReadValue<Vector2>().normalized;
        Debug.Log(direction);
    }

}
