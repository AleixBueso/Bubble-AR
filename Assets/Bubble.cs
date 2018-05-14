using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{

    public Color color;
    public float radius;
    [SerializeField] Renderer render;
    [SerializeField] Collider col;


    private void Start()
    {
        color = render.material.color;
    }

    public Collider[] GetBubbleColliders()
    {
        Collider[] ret = Physics.OverlapSphere(transform.position, radius);
        return ret;
    }

}
