using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TitleButtons : MonoBehaviour {
    public Texture playTex;
    public Texture infoTex;
    public Transform infoScreen;
    bool infoUp = false;
    GameObject info;
    void OnGUI()
    {
        if (GUI.Button(new Rect(500, 300, 50, 50), playTex, new GUIStyle()))
        {
            SceneManager.LoadScene("FirstLevel");
        }
        if (GUI.Button(new Rect(450, 300, 50, 50), infoTex, new GUIStyle()))
        {
            if (!infoUp)
            {
                Instantiate(infoScreen, new Vector3(0, .4f, 0), Quaternion.identity);
                infoUp = true;
            }
            else { info.SendMessage("onInfoClose", SendMessageOptions.DontRequireReceiver);
            infoUp = false;
            }
        }
    }
    void catchInfo(GameObject inform)
    {
        info = inform;
    }
}
