using UnityEngine;
using System.Collections;

public class closeInfo : MonoBehaviour {

    void onInfoClose()
    {
        Destroy(gameObject);
    }

    void OnBecameVisible()
    {
        Camera.main.SendMessage("catchInfo", gameObject);
    }
}
