using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    float timer;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        if (timer > 4f)
        {
            Destroy(gameObject);
            timer = 0;
        }
	}

    void OnTriggerEnter(Collider co)
    {
        if (co.transform.name == "PlanatoidGround") {
            Destroy(gameObject);
        }

    }

}
