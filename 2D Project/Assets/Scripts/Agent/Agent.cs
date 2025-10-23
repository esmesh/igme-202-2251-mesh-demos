using UnityEditor.Experimental.GraphView;
using UnityEngine;

public abstract class Agent : MonoBehaviour
{
    // Making these serilaized only for debug purposes. Should generally NOT
    // be accessible outside this component!

    [SerializeField]
    Vector3 position = Vector3.zero; // distance

    [SerializeField]
    Vector3 velocity = Vector3.zero; // distance/second

    [SerializeField]
    Vector3 acceleration = Vector3.zero; // velocity/second --> distance/second^2

    [SerializeField]
    float maxSpeed = 5.0f;

    [SerializeField]
    Bounds agentBounds;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // OLD movement code
        /*
        velocity = direction * speed;
        position += velocity * Time.deltaTime;
        */

        // Calculate acceleration
        acceleration = CalcSteeringForces();

        // Update velocity
        velocity += acceleration * Time.deltaTime;
        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);

        // Update position
        position += velocity * Time.deltaTime;
        transform.position = position;
    }

    protected abstract Vector3 CalcSteeringForces();

    protected Vector3 Seek(Vector3 targetPos)
    {
        // Calc desired velocity
        Vector3 desiredVelocity = targetPos - position;

        // Opt 0 -- desiredVelocity based solely on positions
        // scales based on dist to target
        // arrival like -- always scales vs within a radius

        // ideal seek - always go as fast as I'm allowed
        Vector3 opt1 = desiredVelocity.normalized * maxSpeed;

        // effectively an arrival where radius == maxSpeed
        // Vector3 opt2 = Vector3.ClampMagnitude(desiredVelocity, maxSpeed);

        desiredVelocity = opt1;

        // Calc seeking force
        Vector3 seekForce = desiredVelocity - velocity;
        seekForce.z = 0;

        // return final force
        return seekForce;
    }

    protected Vector3 Arrive(Vector3 targetPos, float arrivalRadius)
    {
        // Calc desired velocity
        Vector3 desiredVelocity = targetPos - position;

        // Are we "arriving"?
        if(desiredVelocity.sqrMagnitude < arrivalRadius * arrivalRadius)
        {
            float percent = desiredVelocity.magnitude / arrivalRadius;
            desiredVelocity = desiredVelocity.normalized * (maxSpeed * percent);
        }
        else
        {
            desiredVelocity = desiredVelocity.normalized * maxSpeed;
        }

        // Calc seeking force
        Vector3 arriveForce = desiredVelocity - velocity;
        arriveForce.z = 0;

        // return final force
        return arriveForce;
    }

    protected Vector3 StayInBoundsForce()
    {
        if (!agentBounds.Contains(position))
        {
            return Seek(agentBounds.center);
        }
        return Vector3.zero;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(position, position + velocity);

        Gizmos.color = Color.green;
        Gizmos.DrawLine(position, position + acceleration);

        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(agentBounds.center, agentBounds.size);
    }
}
