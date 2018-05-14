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

    public List<Bubble> GetBubbleColliders()
    {
        
        List<Bubble> ret = new List<Bubble>();
        Collider[] cols = Physics.OverlapSphere(transform.position, radius);
        Debug.DrawLine(cols[0].transform.position, new Vector3(cols[0].transform.position.x + radius, cols[0].transform.position.y, cols[0].transform.position.z));


        for (int i = 0; i < cols.Length; i++)
        {

            if (cols[i].gameObject.tag == "Bubble" && cols[i].gameObject != this.gameObject)
            {
                //if (gm.all_bubbles.Exists(cols[i].GetComponent<Bubble>())
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
