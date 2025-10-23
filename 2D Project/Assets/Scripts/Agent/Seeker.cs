using UnityEngine;

public class Seeker : Agent
{

    [SerializeField]
    Transform target;

    [SerializeField, Range(0,1)]
    float targetWeight = 1;

    [SerializeField, Range(0,1)]
    float boundsWeight = 1;

    protected override Vector3 CalcSteeringForces()
    {
        return targetWeight * Seek(target.position) + boundsWeight * StayInBoundsForce();
    }
}
