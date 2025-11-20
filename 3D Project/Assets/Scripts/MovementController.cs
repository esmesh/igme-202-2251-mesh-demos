using UnityEngine;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour
{
    [SerializeField]
    float speed;

    // public for debug purposes
    public Vector3 moveDirection = Vector3.zero;
    public Vector3 velocity = Vector3.zero;


    // Update is called once per frame
    void Update()
    {
        if (moveDirection != Vector3.zero)
        {
            // Determine the velocity based on player direction & speed
            // axis by axis

            // left/right -- along player's right vector
            velocity = transform.right * moveDirection.x;

            // fwd/back
            velocity += transform.forward * moveDirection.y;

            transform.position += velocity * speed * Time.deltaTime;
        }
    }


    public void OnMove(InputAction.CallbackContext context)
    {
        moveDirection = context.ReadValue<Vector2>();
    }


}
