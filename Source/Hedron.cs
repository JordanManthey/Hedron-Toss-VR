using HedronStateMachine;
using UnityEngine;
using StatHelpers;

public class Hedron : MonoBehaviour
{
    public Rigidbody HedronRB { get; set; }
    public HedronState State { get; set; }

    [SerializeField] protected float BounceScalarX;
    [SerializeField] protected float BounceScalarY;
    [SerializeField] protected float BounceScalarZ;

    // Teleports the hedron if the current HedronState allows it.
    public void Teleport(Vector3 newPosition)
    {
        if (State.GetAllowTeleport())
        {
            HedronRB.velocity = Vector3.zero;
            HedronRB.angularVelocity = Vector3.zero;
            transform.position = newPosition;
        }
    }

    // Bounces the hedron in a direction between the provided bounceObject's boundaries.
    // The direction is randomly chosen from a normal distribution between the boundaries.
    public void Bounce(GameObject bounceObject)
    {
        if (transform.childCount > 1)
        {
            // This bounceObject's left and right boundaries to bounce the hedron through.
            Transform leftBound = bounceObject.transform.GetChild(0);
            Transform rightBound = bounceObject.transform.GetChild(1);

            if (leftBound.tag == "Bounce_Boundary" && rightBound.tag == "Bounce_Boundary")
            {
                float xMin = Mathf.Min(leftBound.position.x, rightBound.position.x);
                float xMax = Mathf.Max(leftBound.position.x, rightBound.position.x);
                float zMin = Mathf.Min(leftBound.position.z, rightBound.position.z);
                float zMax = Mathf.Max(leftBound.position.z, rightBound.position.z);

                // Calculating the direction of the hedron's bounce on X and Z axis (randomly from normal distribution), then normalizing.
                Vector3 gaussianVector = new Vector3(Calculator.RandomGaussian(xMin, xMax), 1, Calculator.RandomGaussian(zMin, zMax));
                Vector3 bounceDirection = (transform.position - gaussianVector).normalized;

                // Applying directional force on the hedron based on its BounceScalar properties set in Unity inspector.
                HedronRB.AddForce(bounceDirection.x * BounceScalarX, bounceDirection.y * BounceScalarY, bounceDirection.z * BounceScalarZ);
            }
        }
    }

    // All collisions with the Hedron are delegated by its current HedronState.
    private void OnCollisionEnter(Collision collision)
    {
        State.HandleCollision(this, collision);
    }
}
