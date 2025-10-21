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

        // Update position
        position += velocity * Time.deltaTime;
        transform.position = position;
    }

    protected abstract Vector3 CalcSteeringForces();

    protected Vector3 Seek(Vector3 targetPos)
    {
        // Calc desired velocity
        Vector3 desiredVelocity = targetPos - position;

        // Cap desired by max speed
        desiredVelocity = desiredVelocity.normalized * maxSpeed;

        // Calc seeking force
        Vector3 seekForce = desiredVelocity - velocity;
        seekForce.z = 0;

        // return final force
        return seekForce;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(position, position + velocity);

        Gizmos.color = Color.green;
        Gizmos.DrawLine(position, position + acceleration);
    }
}
