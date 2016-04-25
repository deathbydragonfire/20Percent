using UnityEngine;
using System.Collections;

public class Touch : MonoBehaviour {

    SpriteRenderer sr;
    public Sprite red;
    public Sprite blue;
    public Sprite green;
    public Sprite purple;
    public Sprite orange;
    string binName;
    int color;
    /* public Vector2 binR;
    public Vector2 binB;
    public Vector2 binG;
    public Vector2 binP;
    public Vector2 binO; */
    Vector2 binPosition;
    public float toleranceX;
    public float toleranceY;
    bool selected; //box selected
    bool isThis;
    public bool followTrack = true; //for testing, can disable movement of box along track
    float trackX; //X position when following track
    float trackY; //Y position when following track
    public float speed = 0.1f; //Speed of box while following track (Should be same as track speed for best result)


   

	void Start () {
        GameObject go = transform.gameObject;
        sr = go.GetComponent<SpriteRenderer>();

        if (sr.sprite == red) {
            color = 1;
            //binPosition = binR;
            binName = "barRed";  //must name exactly this in hirarchy!!!!!!
        } else if (sr.sprite == blue) {
            color = 2;
            //binPosition = binB;
            binName = "barBlue";  //must name exactly this in hirarchy!!!!!!
        } else if (sr.sprite == green) {
            color = 3;
            //binPosition = binG;
            binName = "barGreen";  //must name exactly this in hirarchy!!!!!!
        } else if (sr.sprite == purple) {
            color = 4;
            //binPosition = binP;
            binName = "barPurple";  //must name exactly this in hirarchy!!!!!!
        } else if (sr.sprite == orange) {
            color = 5;
            //binPosition = binO;
            binName = "barOrange";  //must name exactly this in hirarchy!!!!!!
        }
        else { color = -1; }
        print(transform.gameObject);
        //GameObject.Find(binName).SendMessage("findBox", transform.gameObject);
        GameObject.Find("binBlue").SendMessage("getPosition");
        selected = false;
        isThis = false;
        if (followTrack)
        {
            trackX = -8.5f; //Sets start X position at -8.5
            trackY = Random.Range(-2.3f, -1.1f); //Sets starting Y position between -2.3 and -1
            transform.position = new Vector3(trackX, trackY, 1 - trackY);
        }
	}

    void acceptPosition(Vector2 pos)
    {
        binPosition = pos;
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
                    print("hit");
                    if (overBin()) { GameObject.Find(binName).SendMessage("boxOver", transform.gameObject); }
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

    //methods to be called by other gameObjects

    void speedUp()
    {
        speed += .01f;
    }

    void speedDown()
    {
        speed -= .01f;
    }
    void checkColor(int col)
    {
        bool good = false;
        while (Input.touchCount < 0) { good = overBin(); }
        if ((col == color) && good)
        {
            GameObject.Find("LifeBar").SendMessage("onLifeUp");
            Destroy(gameObject);
        }
    }
}
