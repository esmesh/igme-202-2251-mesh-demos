using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class SmartSeeker : Agent
{
    // Fields for Seeker
    [SerializeField] ChildTracker targetTracker;
    [SerializeField, Range(0, 1)] float seekScalar;
    [SerializeField, Range(0, 1)] float boundsStrength = 1f;
    [SerializeField] SeekMode mode = SeekMode.Furthest;

    public enum SeekMode
    {
        Furthest,
        Closest,
        AveragePosition
    }

    public void DropdownValueChanged(Dropdown change)
    {
        mode = (SeekMode)change.value;
    }
    // Calculate the steering force
    protected override Vector3 CalcSteeringForces()
    {
        Vector3 targetPos = Vector3.zero;
        if (targetTracker.Count > 0)
        {
            switch (mode)
            {
                case SeekMode.Closest:
                    targetPos = targetTracker.FindClosestChild(transform.position).transform.position;
                    break;

                case SeekMode.Furthest:
                    targetPos = targetTracker.FindFurthestChild(transform.position).transform.position;
                    break;

                case SeekMode.AveragePosition:
                    targetPos = targetTracker.AveragePosition;
                    break;
            }
        }
        return Seek(targetPos) * seekScalar +
                StayInBoundsForce() * boundsStrength;
    }

}
