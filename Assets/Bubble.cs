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
        InitColor();
        gm.all_bubbles.Add(this);
    }

    private void FixedUpdate()
    {
        transform.localPosition = new Vector3(transform.localPosition.x, 0, transform.localPosition.z);
    }

    public Collider[] GetBubbleColliders()
    {
        Collider[] ret = Physics.OverlapSphere(transform.position, radius);
        return ret;
    }

    private void InitColor()
    {
        int rnd = Random.RandomRange(0, 4);
        color = gm.colors[rnd];
        render.material.color = color;
    }

}
