using UnityEngine;
using System.Collections;

public class FireCube : MonoBehaviour       
{

    Ray ray;
    RaycastHit hit;
    public GameObject prefab;
    float timer;
    GameObject obj;
    Rigidbody oRb;
    public Transform cameraT;
    public float fireForce = 250f;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;      
        if (Input.GetKey(KeyCode.Mouse0) || Input.touchCount > 0)
        {
            
            if (timer > 1.0f)
            {
                GameObject go = Instantiate(prefab, cameraT.transform.position, cameraT.transform.rotation) as GameObject;
                Rigidbody rb = go.GetComponent<Rigidbody>();

                rb.AddForce(cameraT.transform.forward * fireForce);
                timer = 0;
                
            }
        }
    }
}
