using UnityEngine;
using System.Collections;
using System.Threading;

public class SpawnBoxes : MonoBehaviour {
    public bool spawnActive = true;
    public int frequency = 50; // between 1 and 100, lower numbers = higher frequency
    public Transform redBox;
    public Transform blueBox;
    public Transform greenBox;
    public Transform purpleBox;
    public Transform orangeBox;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        int color = Random.Range(1, 5);
        int time = Random.Range(1, 100);
        if (time > frequency)
        {
            switch (color)
            {
                case 1:
                    {
                        Instantiate(redBox, new Vector3(-8, -1, -1), Quaternion.identity);
                        break;
                    }
                case 2:
                    {
                        Instantiate(blueBox, new Vector3(-8, -1, -1), Quaternion.identity);
                        break;
                    }
                case 3:
                    {
                        Instantiate(greenBox, new Vector3(-8, -1, -1), Quaternion.identity);
                        break;
                    }
                case 4:
                    {
                        Instantiate(purpleBox, new Vector3(-8, -1, -1), Quaternion.identity);
                        break;
                    }
                case 5:
                    {
                        Instantiate(orangeBox, new Vector3(-8, -1, -1), Quaternion.identity);
                        break;
                    }
            }
        }
	}
}
