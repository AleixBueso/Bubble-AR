using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    [SerializeField] Transform bubble;
    private Transform spawnPosition;
	
	// Update is called once per frame
	void Update () {
		

        if(Input.GetButton("Fire1"))
        {
            CreateBubble();
        }
	}

    private void CreateBubble()
    {
        GameObject go = Instantiate(bubble, spawnPosition.position, transform.rotation).gameObject;
        go.GetComponent<Rigidbody>().AddForce(transform.forward, ForceMode.Impulse);
    }
}
