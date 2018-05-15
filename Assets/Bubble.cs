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
        //InitColor();
        gm.all_bubbles.Add(this);
    }

    private void FixedUpdate()
    {
        transform.localPosition = new Vector3(transform.localPosition.x, 0, transform.localPosition.z);
    }

    public List<Bubble> GetBubbleColliders()
    {
        
        List<Bubble> ret = new List<Bubble>();
        Collider[] cols = Physics.OverlapSphere(transform.position, radius);


        for (int i = 0; i < cols.Length; i++)
        {

            if (cols[i].gameObject.tag == "Bubble" && cols[i].gameObject != this.gameObject)
            {
                ret.Add(cols[i].GetComponent<Bubble>());
            }
        }

        return ret;
    }

    private void InitColor()
    {
        int rnd = Random.Range(0, 4);
        color = gm.colors[rnd];
        render.material.color = color;
    }

}
