using UnityEngine;
using System.Collections;

public class lifeBar : MonoBehaviour {
    
    //sprite references
    int life = 20;
    SpriteRenderer sr;
    Sprite[] sprites = new Sprite[21];
    public Sprite full;
    public Sprite m1;
    public Sprite m2;
    public Sprite m3;
    public Sprite m4;
    public Sprite m5;
    public Sprite m6;
    public Sprite m7;
    public Sprite m8;
    public Sprite m9;
    public Sprite m10;
    public Sprite m11;
    public Sprite m12;
    public Sprite m13;
    public Sprite m14;
    public Sprite m15;
    public Sprite m16;
    public Sprite m17;
    public Sprite m18;
    public Sprite m19;
    public Sprite empty;

	void Start () {
        GameObject go = transform.gameObject;
        sr = go.GetComponent<SpriteRenderer>();
        sr.sprite = full;
        sprites[0] = empty;
        sprites[1] = m19;
        sprites[2] = m18;
        sprites[3] = m17;
        sprites[4] = m16;
        sprites[5] = m15;
        sprites[6] = m14;
        sprites[7] = m13;
        sprites[8] = m12;
        sprites[9] = m11;
        sprites[10] = m10;
        sprites[11] = m9;
        sprites[12] = m8;
        sprites[13] = m7;
        sprites[14] = m6;
        sprites[15] = m5;
        sprites[16] = m4;
        sprites[17] = m3;
        sprites[18] = m2;
        sprites[19] = m1;
        sprites[20] = full;
	}
	

    void onLifeDown()
    {
        if (life > 0)
        {
            life--;
            sr.sprite = sprites[life];
        }
    }
    void onLifeUp()
    {
        if (life < 20)
        {
            life++;
            sr.sprite = sprites[life];
        }
    }
}
