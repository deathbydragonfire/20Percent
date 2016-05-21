using UnityEngine;
using System.Collections;

public class Utility : MonoBehaviour {

    
    public float speed = .1f;
	// Use this for initialization
	void Start () {
        GameObject.Find("belt").SendMessage("speedSet", speed);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void newBox(GameObject box)
    {
        box.SendMessage("speedSet", speed);
    }
    void speedUp()
    {
        speed += .05f;
        GameObject[] objects = (GameObject[])FindObjectsOfType(typeof(GameObject));
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i].SendMessage("speedSet", speed,  SendMessageOptions.DontRequireReceiver);
        }
    }
}
