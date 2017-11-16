using UnityEngine;

/// <summary>
/// Controls the Laser Sight for the player's aim
/// </summary>
public class TrajectorySimulation : MonoBehaviour
{
    // Reference to a Component that holds information about fire strength, location of cannon, etc.
    public CannonShoot cannonShoot;
    // Reference to the LineRenderer we will use to display the simulated path
    public LineRenderer trajectory;

    public Transform trajectoryStartingPoint;
    public Color trajectoryColor = Color.red;
    

    // Number of segments to calculate - more gives a smoother line
    public int resolution = 20;

    // Length scale for each segment
    public float segmentScale = 1;

    // gameobject we're actually pointing at (may be useful for highlighting a target, etc.)
    private Collider _hitObject;
    public Collider hitObject { get { return _hitObject; } }


    void FixedUpdate()
    {
        drawTrajectory();
    }

    /// <summary>
    /// Simulate the path of a launched ball.
    /// Slight errors are inherent in the numerical method used.
    /// </summary>
    void drawTrajectory()
    {
        Vector3[] segments = new Vector3[resolution];

        // The first line point is wherever the player's cannon, etc is
        segments[0] = trajectoryStartingPoint.transform.position;

        // The initial velocity
		Vector3 segVelocity = trajectoryStartingPoint.transform.forward * cannonShoot.shootVelocity * 50 * Time.deltaTime;

        // reset our hit object
        _hitObject = null;

        for (int i = 1; i < resolution; i++)
        {
            // Time it takes to traverse one segment of length segScale (careful if velocity is zero)
            float segTime = (segVelocity.sqrMagnitude != 0) ? segmentScale / segVelocity.magnitude : 0;

            // Add velocity from gravity for this segment's timestep
            segVelocity = segVelocity + Physics.gravity * segTime;
            segments[i] = segments[i - 1] + segVelocity * segTime;
        }

        // At the end, apply our simulations to the LineRenderer

        // Set the colour of our path to the colour of the next ball
        Color startColor = Color.red;
        Color endColor = startColor;
        startColor.a = 1;
        endColor.a = 0;
        trajectory.SetColors(startColor, endColor);

        trajectory.SetVertexCount(resolution);
        for (int i = 0; i < resolution; i++)
            trajectory.SetPosition(i, segments[i]);
    }
}