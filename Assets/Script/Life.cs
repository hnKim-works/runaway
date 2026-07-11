using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Life : MonoBehaviour
{

    public Image[] hearts;
    private int life;
    private bool isGameOver;

    public GUISkin skin; //gameOver
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        life= hearts.Length;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoseLife()
    {
        if (life <= 0) return;

        life--;

        hearts[life].enabled = false; 

        if (life <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        StartCoroutine(Wait(2.0f));
       
    }

    void OnGUI()
    {
        if (isGameOver)
        {
            GameObject gameOut = GameObject.Find("GameOut");
            gameOut.GetComponent<Image>().enabled = true;
            GUI.skin = skin;
            int sw = Screen.width;
            int sh = Screen.height;

            GUI.Label(new Rect(0, sh / 4, sw, sh / 4), "YoU lOsE", "GameOver");
            GUI.Label(new Rect(0, sh / 2, sw, sh / 4), "ReTry? Click", "Retry");

            if (Input.GetButtonDown("Fire1"))  
            {
                Time.timeScale = 1f;
                SceneManager.LoadScene("Stage1");
            }
        }
    }

    IEnumerator Wait(float timer)
    {
        yield return new WaitForSeconds(timer);
        isGameOver = true;
        Time.timeScale = 0f; // ∞‘¿” ∏ÿ√„
    }

}


