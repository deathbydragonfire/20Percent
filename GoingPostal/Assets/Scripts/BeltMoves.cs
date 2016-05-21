using UnityEngine;
using System.Collections;

public class BeltMoves : MonoBehaviour {
    public float speed = 0.1f;
    public float height = -2.38f;
    bool paused = false;

	// Use this for initialization
	void Start () {
	    transform.position = new Vector2(-8.0f, height);
	}
	
	// Update is called once per frame
	void Update () {
        if (!paused)
        {
            if (transform.position.x < 6) { transform.position = new Vector2(transform.position.x + 1.0f * speed, transform.position.y); }
            else { transform.position = new Vector2(-6, height); }
        }
	}

    //methods to be called by other gameobjects

    void speedSet(float sp)
    { 
        speed = sp; 
    }
    void onPauseGame()
    {
        paused = true;
    }
    void onResumeGame()
    {
        paused = false;
    }
}
