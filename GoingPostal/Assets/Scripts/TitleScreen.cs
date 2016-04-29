using UnityEngine;
using System.Collections;

public class TitleScreen : MonoBehaviour {

    int color;
    bool firstTime = true;
    public Sprite red;
    public Sprite blue;
    public Sprite green;
    public Sprite purple;
    public Sprite orange;
    SpriteRenderer sr;
    Sprite[] sprites = new Sprite[5];
	// Use this for initialization
	void Start () {
        GameObject go = transform.gameObject;
        sr = go.GetComponent<SpriteRenderer>();
        color = Random.Range(0, 4);
        sprites[0] = red;
        sprites[1] = blue;
        sprites[2] = green;
        sprites[3] = purple;
        sprites[4] = orange;
	}
	
	// Update is called once per frame
	void Update () {
        int temp = color;
	 RaycastHit hit;
     if (Input.touchCount > 0) //If there is a touch
     {

         Vector3 pos = Input.GetTouch(0).position; //Get its position
         //Debug.Log("Touch " + pos);

         Ray ray = Camera.main.ScreenPointToRay(pos); //check to see if it is colliding with the box
         if (Physics.Raycast(ray, out hit)) 
         {
             if (hit.transform == transform)
             {
                 if (color < 4) { color++; }
                 else { color = 0; }
             }
         }
     }
     if (temp != color || firstTime)
     {
         sr.sprite = sprites[color];
         firstTime = false;
     }
	}
}
