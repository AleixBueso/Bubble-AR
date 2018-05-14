using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    [SerializeField] Transform bubble;
    private Transform spawnPosition;

    float count = 0;
	
	// Update is called once per frame
	void Update () {

        count = Time.deltaTime;


        if(count > 2)
        {
            if (Input.GetButtonUp("Fire1"))
            {
                CreateBubble();
                count = 0;
            }
        }
       
	}

    private void CreateBubble()
    {
        GameObject go = Instantiate(bubble, transform.position, transform.rotation).gameObject;
        go.GetComponent<Rigidbody>().AddForce(transform.forward, ForceMode.Impulse);
    }
}
