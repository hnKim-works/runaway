using UnityEngine;
using UnityEngine.SceneManagement;

public class GameClear : MonoBehaviour
{

    public GUISkin skin;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            SceneManager.LoadScene("TItle1");
        }    
    }

    private void OnGUI()
    {
        GUI.skin = skin;
        int sw = Screen.width;
        int sh = Screen.height;

        GUI.Label(new Rect(0, sh / 4, sw, sh / 4), "¡ÚGame Clear¡Ú", "GameClear");
        GUI.Label(new Rect(0, sh / 2, sw, sh / 4), "Click to Restart", "Exit");
    }
}
