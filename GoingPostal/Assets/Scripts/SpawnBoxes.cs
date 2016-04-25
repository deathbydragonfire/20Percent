using UnityEngine;
using System.Collections;
using System.Threading;

public class SpawnBoxes : MonoBehaviour {
    int color;
    GameObject temp;
    public bool red = true;
    public bool blue = true;
    public bool green = true;
    public bool purple = true;
    public bool orange = true;
    public bool spawnActive = true;
    public int frequency = 900; // between 1 and 1000, lower numbers = higher frequency
    public Transform redBox;
    public Transform blueBox;
    public Transform greenBox;
    public Transform purpleBox;
    public Transform orangeBox;
    private int wait = 0;

    //methods to be called by other objects to control spawner

    void frequencyUp()  //increases rate of spawning
    {
        frequency -= 100;
    }

    void frequencyDown() //decreasing rate of spawning
    {
        frequency += 100;
    }
    void colorOn(string col)
    {
        switch (col) { 
            case "red":
            red = true;
            break;
            case "blue":
            blue = true;
            break;
            case "green":
            green = true;
            break;
            case "purple":
            purple = true;
            break;
            case "orange":
            orange = true;
            break;
            default:
            red = true;
            blue = true;
            green = true;
            purple = true;
            orange = true;
            break;
    }
    }

    

    void boxesON()
    {
        spawnActive = true;
    }

    void boxesOff()
    {
        spawnActive = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (spawnActive)
        {
            color = Random.Range(1, 5);
            int time = Random.Range(1, 1000);
            //print(wait + " " + time);
            if ((time > frequency) && (wait <= 0))
            {
                while ((color > 0) && (red || blue || green || purple || orange))
                {
                    switch (color)
                    {
                        case 1:
                            {
                                if (red)
                                {
                                    Instantiate(redBox, new Vector3(-8, -1, -1), Quaternion.identity);
                                    wait = 50;
                                    //temp.SendMessage("setColor", color);
                                    color = -1;
                                }
                                else { color = Random.Range(1, 5); }
                                break;
                            }
                        case 2:
                            {
                                if (blue)
                                {
                                    Instantiate(blueBox, new Vector3(-8, -1, -1), Quaternion.identity);
                                    wait = 50;
                                    //temp.SendMessage("setColor", color);
                                    color = -1;
                                }
                                else { color = Random.Range(1, 5); }
                                break;
                            }
                        case 3:
                            {
                                if (green)
                                {
                                    temp = (GameObject)Instantiate(greenBox, new Vector3(-8, -1, -1), Quaternion.identity);
                                    wait = 50;
                                    //temp.SendMessage("setColor", color);
                                    color = -1;
                                }
                                else { color = Random.Range(1, 5); }
                                break;
                            }
                        case 4:
                            {
                                if (purple)
                                {
                                    temp = (GameObject)Instantiate(purpleBox, new Vector3(-8, -1, -1), Quaternion.identity);
                                    wait = 50;
                                    //temp.SendMessage("setColor", color);
                                    color = -1;
                                }
                                else { color = Random.Range(1, 5); }
                                break;
                            }
                        case 5:
                            {
                                if (orange)
                                {
                                    temp = (GameObject)Instantiate(orangeBox, new Vector3(-8, -1, -1), Quaternion.identity);
                                    wait = 50;
                                    //temp.SendMessage("setColor", color);
                                    color = -1;
                                }
                                else { color = Random.Range(1, 5); }
                                break;
                            }
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
