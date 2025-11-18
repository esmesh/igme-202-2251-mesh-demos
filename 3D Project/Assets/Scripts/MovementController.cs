using UnityEngine;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour
{
    [SerializeField]
    float speed;

    // public for debug purposes
    public Vector2 moveDirection = Vector2.zero;
    public Vector3 velocity = Vector3.zero;


    // Update is called once per frame
    void Update()
    {
        if (moveDirection != Vector2.zero)
        {
            // Determine the velocity based on player direction & speed
            // axis by axis

            // left/right -- along player's right vector
            velocity = transform.right * moveDirection.x * speed;

            // fwd/back
            velocity += transform.forward * moveDirection.y * speed;

            transform.position += velocity * Time.deltaTime;
        }
    }


    public void OnMove(InputAction.CallbackContext context)
    {
        moveDirection = context.ReadValue<Vector2>();
    }


}
