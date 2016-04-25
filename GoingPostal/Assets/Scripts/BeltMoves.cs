using UnityEngine;
using System.Collections;

public class BeltMoves : MonoBehaviour {
    public float speed = 0.1f;

	// Use this for initialization
	void Start () {
	    transform.position = new Vector2(-8.0f,-2.38f);
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x < 6) { transform.position = new Vector2(transform.position.x + 1.0f * speed, transform.position.y); }
        else { transform.position = new Vector2(-6, -2.38f); }
	}

    //methods to be called by other gameobjects

    void speedUp()
    {
        speed += 0.01f;
    }

    void speedDown()
    {
        speed -= 0.01f;
    }
}
