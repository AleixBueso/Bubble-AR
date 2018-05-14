using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour {

    public float pullRadius = 10;
    public float pullForce = 10;


    public void FixedUpdate()
    {
        foreach (Collider collider in Physics.OverlapSphere(transform.position, pullRadius)) {
            // calculate direction from target to me
            Vector3 forceDirection = transform.position - collider.transform.position;

            // apply force on target towards me
            if(collider.transform.tag == "Bubble")
                collider.GetComponent<Rigidbody>().AddForce(forceDirection.normalized * pullForce * Time.fixedDeltaTime);
        }
    }
}
