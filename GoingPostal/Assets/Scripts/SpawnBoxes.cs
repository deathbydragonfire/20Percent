using UnityEngine;
using System.Collections;
using System.Threading;

public class SpawnBoxes : MonoBehaviour {
    public bool spawnActive = true;
    public int frequency = 900; // between 1 and 1000, lower numbers = higher frequency
    public Transform redBox;
    public Transform blueBox;
    public Transform greenBox;
    public Transform purpleBox;
    public Transform orangeBox;
    private int wait = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (spawnActive)
        {
            int color = Random.Range(1, 5);
            int time = Random.Range(1, 1000);
            //print(wait + " " + time);
            if ((time > frequency) && (wait <= 0))
            {
                switch (color)
                {
                    case 1:
                        {
                            Instantiate(redBox, new Vector3(-8, -1, -1), Quaternion.identity);
                            wait = 50;
                            break;
                        }
                    case 2:
                        {
                            Instantiate(blueBox, new Vector3(-8, -1, -1), Quaternion.identity);
                            wait = 50;
                            break;
                        }
                    case 3:
                        {
                            Instantiate(greenBox, new Vector3(-8, -1, -1), Quaternion.identity);
                            wait = 50;
                            break;
                        }
                    case 4:
                        {
                            Instantiate(purpleBox, new Vector3(-8, -1, -1), Quaternion.identity);
                            wait = 50;
                            break;
                        }
                    case 5:
                        {
                            Instantiate(orangeBox, new Vector3(-8, -1, -1), Quaternion.identity);
                            wait = 50;
                            break;
                        }
                }
            }
            else
            {
                wait--;
            }
        }
	}
}
