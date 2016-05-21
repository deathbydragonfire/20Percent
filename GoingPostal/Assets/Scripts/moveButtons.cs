using UnityEngine;
using System.Collections;

public class moveButtons : MonoBehaviour {
    
    public float frequency = 1000;
    public Texture btnTexL;
    public Texture btnTexR;
    public Texture pauseTex;
    public float speed = 1.0f;
    private bool paused = false;
    private bool leftDwn = false;
    private bool rightDwn = false;
    private float startTime;
    private float journeyLength;
	// Use this for initialization
	void Start () {
        startTime = Time.time;
        
	}
	
	// Update is called once per frame
    void OnGUI()
    {
        if (GUI.Button(new Rect(20, 20, 50, 50), btnTexL, new GUIStyle()))
        {
            if (!paused)
            {
                startTime = Time.time;
                journeyLength = Vector3.Distance(transform.position, new Vector3(-2, 0, -10));
                leftDwn = true;
            }
        }
        if (GUI.Button(new Rect(400, 20, 50, 50), btnTexR, new GUIStyle()))
        {
            if (!paused)
            {
                startTime = Time.time;
                journeyLength = Vector3.Distance(transform.position, new Vector3(2, 0, -10));
                rightDwn = true;
            }
        }
        
        
    }
	void Update () {
       
        if (transform.position.x >= 1.95f) { rightDwn = false; }
        if (transform.position.x <= -1.95f) { leftDwn = false; }
        if (rightDwn)
        {
            
            float distCovered = (Time.time - startTime) * speed;
            float fracJourney = distCovered / journeyLength;
            transform.position = Vector3.Lerp(transform.position, new Vector3 (2, 0, -10), fracJourney);
        }
        else if (leftDwn)
        {
            float distCovered = (Time.time - startTime) * speed;
            float fracJourney = distCovered / journeyLength;
            transform.position = Vector3.Lerp(transform.position, new Vector3(-2, 0, -10), fracJourney);
        }
	} 
}
