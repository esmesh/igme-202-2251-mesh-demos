using UnityEngine;

public class Arriver : Agent
{

    [SerializeField]
    Transform target;

    [SerializeField, Range(0, 1)]
    float targetWeight = 1;

    [SerializeField, Range(0, 1)]
    float boundsWeight = 1;

    [SerializeField]
    float arrivalRadius = 1;

    protected override Vector3 CalcSteeringForces()
    {
        return targetWeight * Arrive(target.position, arrivalRadius) + boundsWeight * StayInBoundsForce();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        if ((target.transform.position - transform.position).magnitude < arrivalRadius)
            Gizmos.color = Color.blue;

        Gizmos.DrawWireSphere(transform.position, arrivalRadius);
    }

}

