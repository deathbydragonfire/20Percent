using UnityEngine;
using System.Collections;

public class Touch : MonoBehaviour
{
    bool paused = false;
    bool exists = true;
    SpriteRenderer sr;
    public Sprite red;
    public Sprite blue;
    public Sprite green;
    public Sprite purple;
    public Sprite orange;
    GameObject rightBin;
    int color;
    Vector2 binPosition;
    public float toleranceX;
    public float toleranceY;
    bool selected; //box selected
    bool isThis;
    public bool followTrack = true; //for testing, can disable movement of box along track
    float trackX; //X position when following track
    float trackY; //Y position when following track
    public float speed = 0.1f; //Speed of box while following track (Should be same as track speed for best result)


    void Start()
    {
        GameObject go = transform.gameObject;
        sr = go.GetComponent<SpriteRenderer>();
        if (sr.sprite == red)
        {
            color = 1;
            GameObject.Find("barRed").SendMessage("findBox", transform.gameObject);
            GameObject.Find("barRed").SendMessage("getBin"); //must name exactly this in hirarchy!!!!!!
        }
        else if (sr.sprite == blue)
        {
            color = 2;
            GameObject.Find("barBlue").SendMessage("findBox", transform.gameObject);
            GameObject.Find("barBlue").SendMessage("getBin");  //must name exactly this in hirarchy!!!!!!
        }
        else if (sr.sprite == green)
        {
            color = 3;
            GameObject.Find("barGreen").SendMessage("findBox", transform.gameObject);
            GameObject.Find("barGreen").SendMessage("getBin");//must name exactly this in hirarchy!!!!!!
        }
        else if (sr.sprite == purple)
        {
            color = 4;
            GameObject.Find("barPurple").SendMessage("findBox", transform.gameObject);
            GameObject.Find("barPurple").SendMessage("getBin");  //must name exactly this in hirarchy!!!!!!
        }
        else if (sr.sprite == orange)
        {
            color = 5;
            GameObject.Find("barOrange").SendMessage("findBox", transform.gameObject);
            GameObject.Find("barOrange").SendMessage("getBin");  //must name exactly this in hirarchy!!!!!!
        }
        else { color = -1; }
        selected = false;
        isThis = false;
        if (followTrack)
        {
            trackX = -8.5f; //Sets start X position at -8.5
            trackY = Random.Range(-2.3f, -1.1f); //Sets starting Y position between -2.3 and -1
            transform.position = new Vector3(trackX, trackY, 1 - trackY);
        }
    }




   
    void Update()
    {
        //test++;
        if (!paused)
        {
            RaycastHit hit;
            if (Input.touchCount > 0) //If there is a touch
            {
                Vector3 pos = Input.GetTouch(0).position; //Get its position
                Ray ray = Camera.main.ScreenPointToRay(pos); //check to see if it is colliding with the box
                if (Physics.Raycast(ray, out hit)) //if it is
                {
                    hit.transform.position = new Vector2(Camera.main.ScreenToWorldPoint(pos).x, Camera.main.ScreenToWorldPoint(pos).y); //Move box to that position
                    selected = true;
                    if (hit.transform == transform)
                    {
                        isThis = true;
                        if (overBin() && exists) { rightBin.SendMessage("boxOver", transform.gameObject); }
                    }
                    else { isThis = false; }
                }
                else { selected = false; isThis = false; }
            }
            else { selected = false; isThis = false; }
            if (!isThis) { selected = false; }
            if ((!selected) && (trackX < 8.5f) && followTrack) //if not selected, on the screen, and movement is enabled
            {
                trackX += speed; //Change X by speed
                transform.position = new Vector2(trackX, trackY); //move box along track
            }
            else if (trackX > 8.5f)
            {
                GameObject.Find("LifeBar").SendMessage("onLifeDown");
                Destroy(gameObject);
            }
        }
    }

    void OnBecameVisible()
    {
        Camera.main.SendMessage("newBox", gameObject);
    }

    //methods to be called by other GameObjects



    bool overBin()
    {
        print("overBin");
        if ((System.Math.Abs(transform.position.x - binPosition.x) <= toleranceX) && ((transform.position.y - binPosition.y) <= toleranceY))
        {
            return true;
        }
        else { return false; }
    }

    





    void speedSet(float sp)
    {
        speed = sp;
    }






    void checkColor(int col)
    {
        print(color + " " + col);
        if ((col == color) && isThis)
        {
            exists = false;
            onPauseGame();
            GameObject.Find("LifeBar").SendMessage("onLifeUp");
            Destroy(gameObject);
        }

    }




    void acceptBin(GameObject bin)
    {
        rightBin = bin;
        binPosition = bin.transform.position;
        print(bin + " " + binPosition);
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
