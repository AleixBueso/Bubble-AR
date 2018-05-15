using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    [SerializeField] Transform bubble;
    private Transform spawnPosition;
    public GameObject cannon;

    public GameObject bubblesParent;

    float count = 0;
	
	// Update is called once per frame
	void Update () {

        count += Time.deltaTime;

        if(count > 2)
        {
            if (Input.GetButtonUp("Fire1"))
            {
                cannon.GetComponent<Animation>().Play();
                CreateBubble();
                count = 0;
            }
        }     
	}

    private void CreateBubble()
    {
        GameObject go = Instantiate(bubble, transform.position, transform.rotation, bubblesParent.transform).gameObject;
        go.GetComponent<Rigidbody>().AddForce(transform.forward, ForceMode.Impulse);
    }
}
