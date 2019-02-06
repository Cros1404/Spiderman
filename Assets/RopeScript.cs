using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(HingeJoint2D))]
[RequireComponent(typeof(HingeJoint2D))]

public class RopeScript : MonoBehaviour
{
    private HingeJoint2D playerJoint;
    private HingeJoint2D targetJoint;
    private LineRenderer lineRenderer;

    void Awake()
    {
        HingeJoint2D[] hingeJoints;
        hingeJoints = GetComponents<HingeJoint2D>();
        if (hingeJoints.Length != 2)
        {
            throw new UnityException("There should only be 2 HingeJoint2D components");
        }
        foreach (HingeJoint2D hingeJoint in hingeJoints)
        {
            if (hingeJoint.connectedBody)
            {
                playerJoint = hingeJoint;
            }
            else
            {
                targetJoint = hingeJoint;
            }
        }
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        Transform currentTransform = transform;
        Vector2 targetVector = targetJoint.anchor;
        Vector2 playerVector = Vector2.MoveTowards(playerJoint.connectedBody.position, targetVector, 0.2f);
        
        Vector3[] vectors = {playerVector, targetVector};
        lineRenderer.SetPositions(vectors);
    }
}
