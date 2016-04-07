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
        if (transform.position.x < 6.75f) { transform.position = new Vector2(transform.position.x + 1.0f * speed, transform.position.y); }
        else { transform.position = new Vector2(-6.75f, -2.38f); }
	}
}
