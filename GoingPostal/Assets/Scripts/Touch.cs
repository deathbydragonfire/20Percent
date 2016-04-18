using UnityEngine;
using System.Collections;

public class Touch : MonoBehaviour {

    public Vector2 binPosition;
    public float toleranceX;
    public float toleranceY;
    bool selected; //box selected
    bool isThis;
    public bool followTrack = true; //for testing, can disable movement of box along track
    float trackX; //X position when following track
    float trackY; //Y position when following track
    public float speed = 0.1f; //Speed of box while following track (Should be same as track speed for best result)

   
   
	void Start () {
        
        selected = false;
        isThis = false;
        if (followTrack)
        {
            trackX = -8.5f; //Sets start X position at -8.5
            trackY = Random.Range(-2.3f, -1.1f); //Sets starting Y position between -2.3 and -1
            transform.position = new Vector3(trackX, trackY, 1 - trackY);
        }
	}

    
	void Update () {
        //test++;
        RaycastHit hit;
        if (Input.touchCount > 0) //If there is a touch
        {
            
            Vector3 pos = Input.GetTouch(0).position; //Get its position
            //Debug.Log("Touch " + pos);

            Ray ray = Camera.main.ScreenPointToRay(pos); //check to see if it is colliding with the box
            if (Physics.Raycast(ray, out hit)) //if it is
            {
                
                hit.transform.position = new Vector2(Camera.main.ScreenToWorldPoint(pos).x, Camera.main.ScreenToWorldPoint(pos).y); //Move box to that position
                selected = true;
                if (hit.transform == transform)
                {
                    if (overBin()) { GameObject.Find("mailRed2").SendMessage("boxOver"); print("OVER"); }
                    isThis = true;
                }
                else { isThis = false; }
                //Debug.Log("Something hit " + Camera.main.ScreenToWorldPoint(pos));
            }
            else { selected = false; isThis = false; }

        }
        else { selected = false; isThis = false; }
        if (!isThis) { selected = false; }
        if ((!selected)&&(trackX < 8.5f)&&followTrack) //if not selected, on the screen, and movement is enabled
        {
            trackX += speed; //Change X by speed
            transform.position = new Vector2(trackX, trackY); //move box along track
        }
        else if (trackX > 8.5f)
        {
            GameObject.Find("LifeBar").SendMessage("onLifeDown");
            Destroy(gameObject);
        }
        //Debug.Log(test + " " + selected);
	}
    bool overBin()
    {
        if ((System.Math.Abs(transform.position.x - binPosition.x) <= toleranceX) && ((transform.position.y - binPosition.y) <= toleranceY))
        {
            return true;
        }
        else { return false; }
    }
}
