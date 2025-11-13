using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectClicker : MonoBehaviour
{
    [SerializeField]
    LayerMask interactionLayer;

    public void OnAttack(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            // setup where to store hit info
            RaycastHit hitInfo;

            // fire a ray from current position to where this is looking
            // see if hit something (that I care about)
            if(Physics.Raycast(
                transform.position,
                transform.forward,
                out hitInfo,
                Mathf.Infinity,
                interactionLayer))
            {
                Debug.Log("HIT");
                // Interact with the thing I hit
                // hitInfo.collider.GetComponent <????> ();
            }

        }
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * 100);
    }

}
