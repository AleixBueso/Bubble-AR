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
        if (all_bubbles.Count >= 3)
        {
            for (int i = 0; i < all_bubbles.Count; i++)
            {
                if (CheckTrippleBubble(all_bubbles[i]))
                    break;
            }
        }
    }

    private bool CheckTrippleBubble(Bubble b)
    {
        if (b == null)
            return false;

       List<Bubble> colBubbles =  b.GetBubbleColliders();

        for(int i = 0; i < colBubbles.Count; i++)
        {
                Bubble x1 = colBubbles[i];
                if (x1.color == b.color)
                {
                    List<Bubble> colBubbles2 = x1.GetBubbleColliders();
                    for (int j = 0; j < colBubbles2.Count; j++)
                    {
                        Bubble x2 = colBubbles2[j].gameObject.GetComponent<Bubble>();

                        if (x2.color == x1.color && x2 != b && x2 != x1)
                        {
                            PopSerie(b, x1, x2);
                        return true;
                        }
                    }
                }
        }

        return false;
    }

    private void PopSerie(Bubble a, Bubble b, Bubble c)
    {
        //Implement delete
        all_bubbles.Remove(a);
        all_bubbles.Remove(b);
        all_bubbles.Remove(c);

        points += 10;

        DestroyImmediate(a);
        DestroyImmediate(b);
        DestroyImmediate(c);
    }
}
