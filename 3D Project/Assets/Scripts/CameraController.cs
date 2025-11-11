using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    Camera playerCam;

    [SerializeField]
    bool yLookInversion = false;

    [SerializeField]
    Vector2 lookSensitivity = Vector2.one;

    public void OnLook(InputAction.CallbackContext context)
    {
        // read the mouse displacement
        Vector2 lookInput = context.ReadValue<Vector2>();

        // turn player left/right
        if(lookInput.x != 0f)
        {
            transform.Rotate(0f, lookInput.x * lookSensitivity.x, 0f);
        }

        // rotate camera up/down
        if(lookInput.y != 0f)
        {
            if(yLookInversion)
            {
                lookInput.y *= -1f;
            }

            playerCam.transform.Rotate(lookInput.y * lookSensitivity.y, 0f, 0f);
        }


    }

}
