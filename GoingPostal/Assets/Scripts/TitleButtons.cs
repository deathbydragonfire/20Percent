using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TitleButtons : MonoBehaviour {
    public Texture playTex;
    public Texture infoTex;
    public Transform infoScreen;
    bool infoUp = false;
	void OnGUI() {
        if (GUI.Button(new Rect(450, 290, 50, 50), playTex, new GUIStyle())) {
            SceneManager.LoadScene("testScene");
        }
        if (GUI.Button(new Rect(450, 200, 50, 50), infoTex, new GUIStyle()))
        {
            if (!infoUp)
            {
                Instantiate(infoScreen, new Vector3(0, 0, 0), Quaternion.identity);
            }
        }
    }
    void closeInfo()
    {
        infoUp = false;
    }
}
