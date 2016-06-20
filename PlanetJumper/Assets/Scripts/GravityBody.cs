using UnityEngine;
using System.Collections;

public class GravityBody : MonoBehaviour
{

    GravityAttractor attractor;

    Rigidbody rb;

    public bool faceSpheroid;
    public bool canLeave;
    private bool isJumping = false;
    public float force;
    private GravityAttractor _oldAttractor;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        rb.useGravity = false;
        rb.AddForce(transform.forward * force);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (attractor != null && !isJumping)
        {
            attractor.Attractor(transform, faceSpheroid);
        }
    }

    public void SetAttractor(GravityAttractor _attractor)
    {
        if ((_attractor != null && !canLeave) || canLeave)
        {
            attractor = _attractor;
        }

    }

    public void SetIsJumping(bool _isJumping)
    {
        isJumping = _isJumping;
    }

    public Transform GetAttractor()
    {
        return attractor.transform;
    }
}
