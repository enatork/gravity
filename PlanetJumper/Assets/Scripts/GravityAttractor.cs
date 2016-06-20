using UnityEngine;
using System.Collections;

public class GravityAttractor : MonoBehaviour {

    public float gravityForce = -10f;
    public bool hasDrag;
    public float drag;
    public void Attractor(Transform body, bool isRotate)
    {
        Vector3 gravityUp = (body.position - transform.position).normalized;
        Vector3 bodyUp = body.up;
        Rigidbody bodyRb = body.GetComponent<Rigidbody>();
        
        bodyRb.AddForce(gravityUp * gravityForce);

        if (isRotate)
        {
            Quaternion targetRotation = Quaternion.FromToRotation(bodyUp, gravityUp) * body.rotation;

            body.rotation = Quaternion.Slerp(body.rotation, targetRotation, 50 * Time.deltaTime);
        }
        
    }

    void OnTriggerEnter(Collider co)
    {
        if (co.GetComponent<GravityBody>())
        {
            GravityBody gb = co.GetComponent<GravityBody>();
            Rigidbody rb = co.GetComponent<Rigidbody>();


            gb.SetAttractor(transform.GetComponent<GravityAttractor>());
            if (hasDrag)
            {
                rb.drag = drag;
            }
        }
    }

    void OnTriggerExit(Collider co)
    {
        if (co.GetComponent<Orbital>())
        {
            GravityBody gb = co.GetComponent<GravityBody>();
            gb.SetAttractor(null);
        }
    }

}
