using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    [SerializeField] Transform bubble;
    private Transform spawnPosition;
	
	// Update is called once per frame
	void FixedUpdate () {
		
        if(Input.GetButtonUp("Fire1"))
        {
            CreateBubble();
        }
	}

    private void CreateBubble()
    {
        GameObject go = Instantiate(bubble, transform.position, transform.rotation).gameObject;
        go.GetComponent<Rigidbody>().AddForce(transform.forward, ForceMode.Impulse);
    }
}
