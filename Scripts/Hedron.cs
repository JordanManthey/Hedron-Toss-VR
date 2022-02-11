using HedronStateMachine;
using UnityEngine;

public class Hedron : MonoBehaviour
{
    public Rigidbody HedronRB { get; set; }
    public HedronState State { get; set; }

    [SerializeField] protected float BounceScalarX;
    [SerializeField] protected float BounceScalarY;
    [SerializeField] protected float BounceScalarZ;

    private void OnCollisionEnter(Collision collision)
    {
        State.HandleCollision(this, collision);
    }

    public void Teleport(Vector3 newPosition)
    {
        if (State.GetAllowTeleport())
        {
            HedronRB.velocity = Vector3.zero;
            HedronRB.angularVelocity = Vector3.zero;
            transform.position = newPosition;
        }
    }

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
                Vector3 bounceDirection = (transform.position - new Vector3(RandomGaussian(xMin, xMax), 1, RandomGaussian(zMin, zMax))).normalized;

                // Applying directional force on the hedron based on its BounceScalar properties set in Unity inspector.
                HedronRB.AddForce(bounceDirection.x * BounceScalarX, bounceDirection.y * BounceScalarY, bounceDirection.z * BounceScalarZ);

            }
        }
    }

    // Returns a random value from a normal distribution between a given min and max value.
    public static float RandomGaussian(float min, float max)
    {
        float u, v, S;

        do
        {
            u = 2.0f * Random.value - 1.0f;
            v = 2.0f * Random.value - 1.0f;
            S = u * u + v * v;
        }
        while (S >= 1.0f);

        // Standard Normal Distribution.
        float std = u * Mathf.Sqrt(-2.0f * Mathf.Log(S) / S);

        // Normal Distribution centered between the min and max.
        float mean = (min + max) / 2.0f;
        float sigma = (max - mean) / 3.0f;
        return Mathf.Clamp(std * sigma + mean, min, max);
    }
}
