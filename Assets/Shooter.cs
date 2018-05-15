using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooter : MonoBehaviour {

    [SerializeField] Transform bubble;
    [SerializeField] Transform spawnPosition;
    public GameObject cannon;

    public GameObject bubblesParent;

    public GameManager gm;

    Color nextColor;
    public Image nextColorImage;

    float count = 0;

    private void Start()
    {
        int rnd = Random.Range(0, 4);
        nextColor = gm.colors[rnd];
        nextColorImage.color = nextColor;
    }

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

                int rnd = Random.Range(0, 4);
                nextColor = gm.colors[rnd];
                nextColorImage.color = nextColor;
            }
        }     
	}

    private void CreateBubble()
    {
        GameObject go = Instantiate(bubble, spawnPosition.position, transform.rotation, bubblesParent.transform).gameObject;
        go.GetComponent<Rigidbody>().AddForce(transform.forward, ForceMode.Impulse);
        go.GetComponent<MeshRenderer>().material.color = nextColor;
        go.GetComponent<Bubble>().color = nextColor;
    }
}
