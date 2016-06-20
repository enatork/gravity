using UnityEngine;
using System.Collections;

public class Orbital : MonoBehaviour {
    public float force;
    Rigidbody rb;

    void Start () {
        rb = gameObject.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * force);
    }


   
}
