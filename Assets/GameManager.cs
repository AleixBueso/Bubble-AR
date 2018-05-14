using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {


    public List<Bubble> all_bubbles;

    public int points = 0;
    public float gameTimer;
    public float maxTime;
    public int maxPoints;

    public Color[] colors;

	// Use this for initialization
	void Start () {
        colors = new Color[5];

        colors[0] = Color.blue;
        colors[1] = Color.red;
        colors[2] = Color.yellow;
        colors[3] = Color.green;
        colors[4] = Color.cyan;

        all_bubbles = new List<Bubble>();
	}
	
	// Update is called once per frame
	void Update () {

        gameTimer = Time.time;

        if(gameTimer > maxTime)
        {
            //you loose
        }

        if(points >= maxPoints)
        {
            //you win
        }
	}

    private void FixedUpdate()
    {
        for(int i = 0; i < all_bubbles.Count; i++)
        {
            CheckTrippleBubble(all_bubbles[i]);
        }
    }

    private void CheckTrippleBubble(Bubble b)
    {
       Collider[] cols =  b.GetBubbleColliders();
       int colSize = cols.Length;

        for(int i = 0; i < colSize; i++)
        {
            if (cols[i].tag == "Bubble" && cols[i] != b)
            {
                Bubble x1 = cols[i].gameObject.GetComponent<Bubble>();
                if (x1.color == b.color)
                {
                    Collider[] cols_x1 = x1.GetBubbleColliders();
                    int size_x1 = cols.Length;

                    for (int j = 0; j < size_x1; j++)
                    {
                        if (cols_x1[j].tag == "Bubble")
                        {
                            Bubble x2 = cols[j].gameObject.GetComponent<Bubble>();
                            if (x2.color == x1.color && x2 != b)
                            {
                                PopSerie(b, x1, x2);
                            }
                        }
                    }
                }
            }
        }
    }

    private void PopSerie(Bubble a, Bubble b, Bubble c)
    {
        //Implement delete
        all_bubbles.Remove(a);
        all_bubbles.Remove(b);
        all_bubbles.Remove(c);

        points += 10;

        Destroy(a);
        Destroy(b);
        Destroy(c);
    }
}
