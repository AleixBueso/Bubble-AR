using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {


    public List<Bubble> all_bubbles;

    public int points = 0;
    public float gameTimer;
    public float maxTime;
    public int maxPoints;

    public GameObject bubblePop;
    public Text scoreText;

    public GameObject center;
    public GameObject worldMarker;

    public Color[] colors;

    [SerializeField] AudioSource pop_bubbles_audio;

    public GameObject pointsPrefab;

	// Use this for initialization
	void Awake () {
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

        points += 100;
        scoreText.text = points.ToString();
        scoreText.GetComponent<Animation>().Play();
        Instantiate(pointsPrefab, b.transform.position, Quaternion.identity, worldMarker.transform);

        GameObject BPop1 = Instantiate(bubblePop, a.transform);
        GameObject BPop2 = Instantiate(bubblePop, b.transform);
        GameObject BPop3 = Instantiate(bubblePop, c.transform);

        pop_bubbles_audio.Play();


        Destroy(BPop1, 1.5f);
        Destroy(BPop2, 1.5f);
        Destroy(BPop3, 1.5f);

        a.gameObject.SetActive(false);
        b.gameObject.SetActive(false);
        c.gameObject.SetActive(false);

        Destroy(a);
        Destroy(b);
        Destroy(c);

        center.GetComponent<Animation>().Play();
    }
}
