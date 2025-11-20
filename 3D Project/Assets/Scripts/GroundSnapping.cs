using UnityEngine;

public class GroundSnapping : MonoBehaviour
{
    [SerializeField] LayerMask layerMask;
    [SerializeField] float yOffset = 1;

    void Update()
    {
        // Raycast needs - origin, direction, max distance, layer
        RaycastHit hitInfo;

        if(Physics.Raycast(transform.position, -transform.up, out hitInfo, Mathf.Infinity, layerMask))
        {
            Vector3 snapPoint = transform.position;
            snapPoint.y = hitInfo.point.y + yOffset;
            transform.position = snapPoint;


            // I want my up to match the surface normal
            // which means my new forward needs to be the vector perp. to the plane
            // formed by my right and the surface normal
            Vector3 newForward = Vector3.Cross(transform.right, hitInfo.normal);
            transform.LookAt(transform.position + newForward, hitInfo.normal);
        }
    }
}
