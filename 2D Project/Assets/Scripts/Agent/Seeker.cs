using UnityEngine;

public class Seeker : Agent
{

    [SerializeField]
    Transform target;

    protected override Vector3 CalcSteeringForces()
    {
        return Seek(target.position);
    }
}
