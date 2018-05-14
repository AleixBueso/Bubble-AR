using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{

    private GameManager gm;
    public Color color;
    public float radius;
    [SerializeField] Renderer render;
    [SerializeField] Collider col;


    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        color = render.material.color;

        gm.all_bubbles.Add(this);
    }

    public Collider[] GetBubbleColliders()
    {
        Collider[] ret = Physics.OverlapSphere(transform.position, radius);
        return ret;
    }

}
