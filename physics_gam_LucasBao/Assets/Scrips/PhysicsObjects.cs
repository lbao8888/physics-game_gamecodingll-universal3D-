using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Experimental.Playables;

public class PhysicsObjects : MonoBehaviour
{
    [Header("Mass and Motion")]
    [Range(0.1f, 100f)]
    public float mass = 1f;

    [Range(0f, 10f)]
    public float drag = 0.5f;

    [Range(0, 10f)]
    public float angularDrag = .5f;

    [Header("Surface Properties")]
    [Range(0, 1f)]
    public float bounciness = 0f;
    [Range(0, 1f)]
    public float friction = 0.6f;

    [Header("Puzzle Properties")]
    public float puzzleWeight = -1f;

    Rigidbody rb;
    PhysicsMaterial physMat;
    public bool isHeld;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        ApplyRigibodySettings();
        ApplySurfaceSettings();
    }

    void ApplyRigibodySettings()
    {
        rb.mass = mass;
        rb.linearDamping = drag;
        rb.angularDamping = angularDrag;
    }

    void ApplySurfaceSettings()
    {
        physMat = new PhysicsMaterial(gameObject.name);
        physMat.bounciness = bounciness;
        physMat.dynamicFriction = friction;
        physMat.staticFriction = friction;

        physMat.frictionCombine = PhysicsMaterialCombine.Average;
        physMat.bounceCombine = PhysicsMaterialCombine.Maximum;

        Collider col = GetComponent<Collider>();
        if (col != null)
        {
            col.material = physMat;
        }

    }

    private void OnValidate()
    {
        if(rb != null) ApplyRigibodySettings();
    }


}
